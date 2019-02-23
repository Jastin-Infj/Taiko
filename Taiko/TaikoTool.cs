using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Taiko
{
    struct 連打ベース
    {
        public int 風船割り中;
        public int 風船割れた;
        public int 連打点;
    }

    public enum ScoreMode
    {
        旧基準,
        新基準,
    };

    struct Score
    {
        public int 最大コンボ数;
        public int 理想天井スコア;
        public ScoreMode scoreMode;
        public int 通常連打数;
        public int 風船割り中;
        public int 風船割れた回数;
    };

    

    public partial class 太鼓スコアシミュレータ : Form
    {
        private bool fileNameflag;
        private string ba風船の情報;
        //読み込んだ専用ファイル
        private List<string> line_全譜面 = new List<string>();
        private List<string> line_鬼譜面 = new List<string>();

        private Score score;
        private 連打ベース rn連打ベース;


        public 太鼓スコアシミュレータ()
        {
            InitializeComponent();
        }
        private void 太鼓スコアシミュレータ_Load(object sender, EventArgs e)
        {
            fileNameflag = false;
            score = new Score();
            score.scoreMode = new ScoreMode();
            rn連打ベース = new 連打ベース();
        }

        private void buttonファイル読み込み_Click(object sender, EventArgs e)
        {
            this.labelスコアINIT.Text = "";
            this.label理想スコア.Text = "";
            //ファイルダイアログボックスを生成する
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //ファイル名の指定をする
            openFileDialog.FileName = "*.tja";
            //初めに開く時のファイルパスを選択する
            openFileDialog.InitialDirectory = "C:/Users/takum/Documents/";
            //ファイル名の種類(読み込み可能ファイルを選択)
            openFileDialog.Filter = "TJAファイル(*.tja)|*.tja";

            //ファイルダイアログのタイトル
            openFileDialog.Title = "TJAファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                this.textBoxTJAファイル読み込み.Text = openFileDialog.FileName;
                this.fileNameflag = true;
            }
            else
            {
                this.fileNameflag = false;
            }
            this.TJAplayer3テキスト読み込み();
        }

        private void textBoxTJAファイル読み込み_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void buttonスコア計算_Click(object sender, EventArgs e)
        {
            //読み込みに成功しているか？
            if (!fileNameflag)
            {
                return;
            }
            this.TJAplayer3鬼譜面配列作成();
        }

        private void TJAplayer3テキスト読み込み()
        {
            //ファイルを読み込み
            StreamReader sr = new StreamReader(textBoxTJAファイル読み込み.Text, Encoding.GetEncoding("Shift_JIS"));

            while (sr.Peek() >= 0)
            {
                //ファイルを1行ずつ読み込み
                string stBuffer = sr.ReadLine();
                this.line_全譜面.Add(stBuffer);
            }
            sr.Close();
        }

        private int TJAplayer3鬼譜面のみ吸い取り不正チェック()
        {
            int flag = 0;
            string[] c_コース名 = { "COURSE:Oni", "COURSE:oni", "COURSE:3", "COURSE:Edit", "COURSE:edit" };
            for (int i = 0; i < c_コース名.Length; ++i)
            {
                if (this.line_全譜面.Contains(c_コース名[i]))
                {
                    flag |= 1;
                }
                if (flag == 1)
                {
                    break;
                }
            }
            //#STARTあるか？
            if (this.line_全譜面.Contains("#START"))
            {
                flag |= 2;
            }
            //#ENDあるか？
            if (this.line_全譜面.Contains("#END"))
            {
                flag |= 4;
            }
            return flag;
        }

        private void TJAplayer3鬼譜面配列作成()
        {
            //フラグが全部通った
            int c_不正チェック通常 = 7;
            if (this.TJAplayer3鬼譜面のみ吸い取り不正チェック() != c_不正チェック通常)
            {
                return;
            }
            string end = "#END";
            int count = 0;

            //線形
            while (this.line_全譜面[count] != end)
            {
                this.line_鬼譜面.Add(this.line_全譜面[count]);
                ++count;
            }
            this.line_鬼譜面.Add(end);
            this.ba風船の情報 = this.風船の情報を取得する();


            //データを取得する
            score.理想天井スコア = this.理想天井スコアの取得();
            score.最大コンボ数 = コンボ数の計算();
            score.通常連打数 = 連打数取得();
            score.風船割り中 = this.風船連打数();
            score.風船割れた回数 = this.風船割れた回数();

            //データ集合
            this.スコア計算(this.score);

            this.line_鬼譜面.Clear();
        }

        private int コンボ数の計算()
        {
            int conbo = 0;
            int counter = 0;
            string nowcheck = null;
            //譜面チェック
            while (counter < this.line_鬼譜面.Count)
            {
                nowcheck = this.line_鬼譜面[counter];
                string now = null;
                //空白しかなかった
                if (nowcheck.Length == 0)
                {
                    ++counter;
                    continue;
                }
                if (nowcheck.Length == 1)
                {
                    now = nowcheck;
                }
                else if (nowcheck.Length == 2)
                {
                    now = nowcheck.Substring(0, 1);
                }
                else
                {
                    now = nowcheck.Substring(0, nowcheck.Length - 1);
                }

                //TITLE:などの文字チェック
                if (!数字譜面確認(now))
                {
                    ++counter;
                    continue;
                }
                //特殊役だった場合
                if (nowcheck.Substring(0, 1) == "#")
                {
                    ++counter;
                    continue;
                }
                //何もない場合
                if (nowcheck.Substring(0, 1) == ",")
                {
                    ++counter;
                    continue;
                }

                //コンボ数を追加する
                conbo += コンボ数追加(now);
                ++counter;
            }
            return conbo;
        }

        private bool 数字譜面確認(string line)
        {
            string check = line.Substring(0, 1);
            int i = 0;
            bool result = int.TryParse(check, out i);
            return result;
        }

        private int コンボ数追加(string line)
        {
            int conbo = 0;
            //線形
            for (int i = 0; i < line.Length; ++i)
            {
                //ドン カッ
                if (line.Substring(i, 1) == "1" || line.Substring(i, 1) == "2")
                {
                    conbo += 1;
                }
                //大音符
                else if (line.Substring(i, 1) == "3" || line.Substring(i, 1) == "4")
                {
                    conbo += 2;
                }
            }
            return conbo;
        }

        private void radioButton新基準_CheckedChanged(object sender, EventArgs e)
        {
            this.score.scoreMode = ScoreMode.新基準;
            this.rn連打ベース.連打点 = 100;
            this.rn連打ベース.風船割り中 = 300;
            this.rn連打ベース.風船割れた = 5000;
        }

        private void radioButton旧基準_CheckedChanged(object sender, EventArgs e)
        {
            this.score.scoreMode = ScoreMode.旧基準;
            this.rn連打ベース.連打点 = 300;
            this.rn連打ベース.風船割り中 = 300;
            this.rn連打ベース.風船割れた = 5000;
        }

        private int 理想天井スコアの取得()
        {
            return (int)this.numericUpDown天井スコア.Value;
        }

        private int 連打数取得()
        {   
            return (int)this.numericUpDown連打数.Value;
        }

        private int 風船割れた回数()
        {
            int ballon = 0;
            if (this.checkBox風船回数自動.CheckState == CheckState.Unchecked)
            {
                return (int)this.numericUpDown風船回数.Value;
            }

            //割れる回数をチェックする
            if(this.ba風船の情報 != null)
            {
                ballon = this.風船回数の取得();
            }

            return ballon;
        }

        private int 風船連打数()
        {
            int ballon = 0;
            if(this.checkBox風船回数自動.CheckState == CheckState.Unchecked)
            {
                //最後のスコア計算は異なるため
                return (int)this.numericUpDown風船連打数.Value - this.風船割れた回数();
            }

            if(this.ba風船の情報 != null)
            {
                ballon = this.風船連打数の取得();
            }
            return ballon;
        }

        private string 風船の情報を取得する()
        {
            int counter = 0;

            string search = null;
            //線形で　文字列の取得する
            for(; counter < this.line_鬼譜面.Count; ++counter)
            {
                if(this.line_鬼譜面[counter].Length < 6)
                {
                    continue;
                }
                if(this.line_鬼譜面[counter].Substring(0,6) == "#START")
                {
                    return null;
                }
                //ある程度認識させる
                if(this.line_鬼譜面[counter].Substring(0,2) != "BA")
                {
                    continue;
                }
                if (this.line_鬼譜面[counter].Substring(0,8) == "BALLOON:")
                {
                    search = this.line_鬼譜面[counter];
                    break;
                }
            }

            //BALLOON:を消す
            search = search.Substring(8, search.Length - 8);

            return search;
        }

        private int 風船回数の取得()
        {
            int count = 0;

            for(int i = 0; i < this.ba風船の情報.Length;++i)
            {
                if(this.ba風船の情報.Substring(i,1) == ",")
                {
                    count += 1;
                }
            }

            //ラストの風船を数える
            count += 1;
            return count;
        }

        private int 風船連打数の取得()
        {
            int count = 0;
            //文字列のコピーをする
            string search = null;
            //初回はAddが飛ばしてしまうので
            bool ballonFirst = false;

            List<int> ballon = new List<int>();

            for(int i = 0; i < this.ba風船の情報.Length;++i)
            {
                if(this.ba風船の情報.Substring(i,1) != ",")
                {
                    //文字列のコピー
                    search += this.ba風船の情報.Substring(i, 1);
                }
                else
                {
                    ballon.Add(int.Parse(search));
                    ballonFirst = true;
                    search = null;
                }
            }
            //1回しか風船をやらない
            if(!ballonFirst)
            {
                ballon.Add(int.Parse(search));
            }
            for(int i = 0; i < ballon.Count;++i)
            {
                count += ballon[i];
            }
            return count;
        }

        private void スコア計算(Score score)
        {
            //理想天井スコアに合わせる作業
            int total_score = score.理想天井スコア;
            //連打回数
            int rendascore_total = this.スコア連打計算(score);
            //風船のスコア
            int rendaballon_total = this.風船のスコア計算(score);
            //理想天井スコアの見直し
            if(this.checkBox連打込みの天井スコア.CheckState == CheckState.Checked)
            {
                total_score -= (rendaballon_total + rendascore_total);
            }
            else
            {
                total_score += (rendaballon_total + rendascore_total);
            }

            int conbo = score.最大コンボ数;

            if(conbo == 0)
            {
                this.label理想スコア.Text = "最大コンボ数が0です";
                return;
            }
            //1conboの点数を計算
            float scoreINIT = total_score / conbo;

            //スコアを四捨五入するか？
            if (this.checkBox小数点を四捨五入する.CheckState == CheckState.Checked)
            {
                int temp = (int)scoreINIT;
                if(scoreINIT - temp > 0.5)
                {
                    scoreINIT += 1;
                }
            }
            int result = (int)scoreINIT;

            if(result < 0)
            {
                this.label理想スコア.Text = "天井スコアが少ないです";
                return;
            }

            this.label理想スコア.Text = "理想スコア:";
            this.labelスコアINIT.Text = result.ToString() + "点";
        }

        private int スコア連打計算(Score score)
        {
            int total = 0;
            int renda = 0;

            //自動算出
            if (checkBox連打数.CheckState == CheckState.Checked)
            {
                //連打数の読み込み
                renda = this.連打数の読み込み();
            }
            else
            {
                renda = (int)this.numericUpDown連打数.Value;
            }

            total = renda * this.rn連打ベース.連打点;
            return total;
        }

        private int 連打数の読み込み()
        {
            int renda = 0;
            return renda;
        }

        private int 風船のスコア計算(Score score)
        {
            int total = 0;
            total += score.風船割り中 * this.rn連打ベース.風船割り中;
            total += score.風船割れた回数 * this.rn連打ベース.風船割れた;
            return total;
        }
    }
}
