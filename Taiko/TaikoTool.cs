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

    struct Score
    {
        public int 最大コンボ数;
        public int 理想天井スコア;
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
        private List<string> line_裏譜面 = new List<string>();
        private List<string> line_難譜面 = new List<string>();
        private List<string> line_普譜面 = new List<string>();
        private List<string> line_簡譜面 = new List<string>();

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
            this.TJAplayer3スコア計算作成();
        }

        private void TJAplayer3テキスト読み込み()
        {
            StreamReader sr = null;
            try
            {
                //ファイルを読み込み
                sr = new StreamReader(textBoxTJAファイル読み込み.Text, Encoding.GetEncoding("Shift_JIS"));
            }
            catch
            {
                return;
            }
           
            while (sr.Peek() >= 0)
            {
                //ファイルを1行ずつ読み込み
                string stBuffer = sr.ReadLine();
                this.line_全譜面.Add(stBuffer);
            }
            sr.Close();

            //対象がnullであるか？
            if (line配列削除するか())
            {
                this.line配列譜面の削除();
            }

            //フラグが全部通った
            int c_不正チェック通常 = 7;
            if (this.TJAplayer3譜面のみ吸い取り不正チェック() != c_不正チェック通常)
            {
                return;
            }

            //対象の配列作成
            this.譜面作成(this.スコア配点の対象の取得());
        }

        private int TJAplayer3譜面のみ吸い取り不正チェック()
        {
            int flag = 0;
            int counter = 0;
            string line = null;
            while(counter < this.line_全譜面.Count)
            {
                line = this.line_全譜面[counter];
                if(line.Length == 0 || line.Length == 1)
                {
                    counter += 1;
                    continue;
                }
                if(line.Substring(0,2) == "CO")
                {
                    flag |= 1;
                    break;
                }
                counter += 1;
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

        private void TJAplayer3スコア計算作成()
        {
            this.ba風船の情報 = this.風船の情報を取得する(スコア配点の対象の取得());

            //データを取得する
            score.理想天井スコア = this.理想天井スコアの取得();
            score.最大コンボ数 = コンボ数の計算(スコア配点の対象の取得());
            score.通常連打数 = 連打数取得();
            score.風船割り中 = this.風船連打数();
            score.風船割れた回数 = this.風船割れた回数();

            //データ集合
            this.スコア計算(this.score);
        }

        private int コンボ数の計算(List<string>list)
        {
            int conbo = 0;
            int counter = 0;
            string nowcheck = null;
            //譜面チェック
            while (counter < list.Count)
            {
                nowcheck = list[counter];
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

        private void 譜面作成(List<string> list)
        {
            string[] checks = null;

            string line_start = "COURSE:";
            string line = null;
            int counter = 0;

            while (true)
            {
                line = this.line_全譜面[counter];
                if (line == "")
                {
                    counter += 1;
                    continue;
                }
                //C以外
                if (line.Substring(0, 1) != "C")
                {
                    list.Add(line);
                    counter += 1;
                    continue;
                }
                //COURSE:のみだった
                if (line == line_start)
                {
                    counter += 1;
                    continue;
                }
                break;
            }

            if (this.radioButtonおに譜面.Checked)
            {
                checks = new string[] { "COURSE:Oni", "COURSE:3", "COURSE:oni" };
            }
            else if (this.radioButton裏譜面その他.Checked)
            {
                checks = new string[] { "COURSE:edit", "COURSE:4", "COURSE:Edit" };
            }
            else if (this.radioButtonかんたん譜面.Checked)
            {
                checks = new string[] { "COURSE:0", "COURSE:Easy", "COURSE:easy" };
            }
            else if (this.radioButtonふつう譜面.Checked)
            {
                checks = new string[] { "COURSE:1", "COURSE:normal", "COURSE:Normal" };
            }
            else if (this.radioButtonむずかしい譜面.Checked)
            {
                checks = new string[] { "COURSE:2", "COURSE:Hard", "COURSE:hard" };
            }

            bool flag = false;

            while (true)
            {
                line = this.line_全譜面[counter];
                //譜面中に空白あり
                if (line.Length == 0)
                {
                    counter += 1;
                    continue;
                }
                if (line.Substring(0, 1) != "C")
                {
                    counter += 1;
                    continue;
                }
                //COURSEの検索
                for (int i = 0; i < checks.Length; ++i)
                {
                    if (line != checks[i])
                    {
                        continue;
                    }

                    //一致した場合
                    flag = true;
                    break;
                }
                if(flag)
                {
                    break;
                }
                //何も一致しない場合
                counter += 1;
            }
            //検索フラグを元に戻す
            flag = false;
            line_start = "#END";

            //譜面のコピーを開始する
            while(true)
            {
                line = this.line_全譜面[counter];
                if(line == "")
                {
                    counter += 1;
                    continue;
                }
                if(line != line_start)
                {
                    list.Add(line);
                    counter += 1;
                    continue;
                }
                else
                {
                    list.Add(line_start);
                    break;
                }
            }
        }

        private List<string> スコア配点の対象の取得()
        {
            if(this.radioButtonおに譜面.Checked)
            {
                return this.line_鬼譜面;
            }
            else if(this.radioButton裏譜面その他.Checked)
            {
                return this.line_裏譜面;
            }
            else if(this.radioButtonむずかしい譜面.Checked)
            {
                return this.line_難譜面;
            }
            else if(this.radioButtonふつう譜面.Checked)
            {
                return this.line_普譜面;
            }
            else if(this.radioButtonかんたん譜面.Checked)
            {
                return this.line_簡譜面;
            }
            return null;
        }

        private bool line配列削除するか()
        {
            //そもそも中身がない
            if(this.line_全譜面 == null)
            {
                return true;
            }
            //チェック項目がついている譜面を確認
            List<string> list = スコア配点の対象の取得();
            //こちらがない
            if(list == null || list.Count == 0)
            {
                return true;
            }

            //タイトル名の確認
            string line = this.line_全譜面[0];
            if(line != list[0])
            {
                return true;
            }

            //同じ対象物だったら削除しない
            return false;
        }

        private void line配列譜面の削除()
        {
            if(this.radioButtonおに譜面.Checked)
            {
                this.line_鬼譜面.Clear();
            }
            else if(this.radioButton裏譜面その他.Checked)
            {
                this.line_裏譜面.Clear();
            }
            else if(this.radioButtonむずかしい譜面.Checked)
            {
                this.line_難譜面.Clear();
            }
            else if(this.radioButtonふつう譜面.Checked)
            {
                this.line_普譜面.Clear();
            }
            else if(this.radioButtonかんたん譜面.Checked)
            {
                this.line_簡譜面.Clear();
            }
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

        private string 風船の情報を取得する(List<string> list)
        {
            int counter = 0;

            string search = null;
            string line = null;

            //COURSE:の中にBALLOONが入っているか？
            bool flag = this.checkBoxCOURSEがない.Checked;

            //線形で　文字列の取得する
            for(; counter < list.Count; ++counter)
            {
                line = list[counter];
                if(line.Length < 6)
                {
                    continue;
                }
                //譜面に入る前に記述されている
                if(line.Substring(0,6) == "#START")
                {
                    return null;
                }
                //ある程度認識させる
                if(line.Substring(0,2) != "BA")
                {
                    continue;
                }
                else if(line.Substring(0,2) == "CO")
                {
                    flag = true;
                }
                if (line.Substring(0,8) == "BALLOON:" && flag)
                {
                    if(line == "BALLOON:")
                    {
                        continue;
                    }
                    search = line;
                    break;
                }
            }

            if(search != null)
            {
                //BALLOON:を消す
                search = search.Substring(8, search.Length - 8);
            }
          
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
            if(!ballonFirst && search != null)
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

            //連打の基準点を確認する
            this.renda連打の基準点を取得();

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
                int renda_total = rendaballon_total + rendascore_total;
                this.label理想スコア.Text = "理想スコア:";
                this.labelスコアINIT.Text = renda_total.ToString() + "点";
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
                this.labelスコアINIT.Text = "";
                return;
            }

            this.label理想スコア.Text = "理想スコア:";
            this.labelスコアINIT.Text = scoreカンマ表記(result.ToString()) + "点";


            //天井スコアの表示
            int total = result * conbo + rendaballon_total + rendascore_total;
            this.label天井スコアの表示.Text = "天井スコアは" + scoreカンマ表記(total.ToString()) + "点";
        }

        private string scoreカンマ表記(string str)
        {
            //1000000
            //1 000 000
            int len = str.Length;
            int kan = len / 3;
            int index = len % 3;

            string result = null;
            int counter = 0;
            //カンマを入れる
            for(int i = 0; i < str.Length;++i)
            {
                result += str.Substring(i, 1);
                if(i + 1 == index && index != 0)
                {
                    result += "'";
                    continue;
                }
                counter += 1;
                if(counter == 3)
                {
                    if(str.Length - 1 != i)
                    {
                        result += "'";
                    }
                }
                
            }
            return result;
        }

        private void renda連打の基準点を取得()
        {
            if(this.radioButton新基準.Checked)
            {
                this.rn連打ベース.連打点 = 100;
                this.rn連打ベース.風船割り中 = 300;
                this.rn連打ベース.風船割れた = 5000;
            }
            else if(this.radioButton旧基準.Checked)
            {
                this.rn連打ベース.連打点 = 300;
                this.rn連打ベース.風船割り中 = 300;
                this.rn連打ベース.風船割れた = 5000;
            }
        }

        private int スコア連打計算(Score score)
        {
            int total = 0;
            int renda = 0;

            //自動算出
            if (checkBox連打数.CheckState == CheckState.Checked)
            {
                //連打数の読み込み
                renda = this.連打数の読み込み(score);
            }
            else
            {
                renda = (int)this.numericUpDown連打数.Value;
            }

            total = renda * this.rn連打ベース.連打点;
            return total;
        }

        private int 連打数の読み込み(Score score)
        {
            int renda = 0;
            string bpm = BPMのデータ取得(スコア配点の対象の取得());
            if (bpm == null)
            {
                return 0;
            }
            renda = BPMによる連打のオート計算(スコア配点の対象の取得(), bpm);
            return renda;
        }

        private string BPMのデータ取得(List<string> list)
        {
            string result = null;
            bool flag = false;
            for (int i = 0; i < list.Count; ++i)
            {
                //Bがない
                if (list[i].Substring(0, 1) != "B")
                {
                    continue;
                }
                //BPM:で終了しているまたはそれ以外
                if (list[i].Length < 4)
                {
                    continue;
                }
                if (list[i].Substring(0, 4) == "BPM:")
                {
                    //これで終了している
                    if (list[i] == "BPM:")
                    {
                        break;
                    }
                    else
                    {
                        result = list[i];
                        flag = true;
                        break;
                    }
                }
            }
            //上手くいった
            if(flag)
            {
                result = result.Substring(4, result.Length - 4);
            }
            return result;
        }

        private int 風船のスコア計算(Score score)
        {
            int total = 0;
            total += score.風船割り中 * this.rn連打ベース.風船割り中;
            total += score.風船割れた回数 * this.rn連打ベース.風船割れた;
            return total;
        }

        private int BPMによる連打のオート計算(List<string>list,string Initbpm)
        {
            float renda = 0;

            float bpm = float.Parse(Initbpm);
            int[] 連打数 = this.連打のバー秒数を求める(list, bpm);
           
            //小連打
            renda += 連打数[0];
            //大連打
            renda += 連打数[1] * 2;
            return (int)renda;
        }
        private int[] 連打のバー秒数を求める(List<string>list,float initbpm)
        {
            int[] total = new int[2];
            List<string>[] renda = this.連打配列作成(list,initbpm);

            //初期配置のみされた
            if(renda[0].Count == 2 && renda[1].Count == 2)
            {
                return null;
            }

            total[0] = this.連打数を自動計算をする(renda[0]);
            total[1] = this.連打数を自動計算をする(renda[1]);

            return total;
        }

        private List<string>[] 連打配列作成(List<string> list,float Initbpm)
        {
            //配列番地を数える
            int counter = 0;

            //一行ずつ読み込みを行うやつ
            string line = null;

            //#STARTまではカウンタを進める
            while (counter < list.Count)
            {
                line = list[counter];
                counter += 1;
                if (line != "#START")
                {
                    continue;
                }
                break;
            }
            List<string> renda_大 = new List<string>();
            List<string> renda_小 = new List<string>();

            line = "BPM: " + Initbpm.ToString();
            //初期BPMを追加する
            renda_大.Add(line);
            renda_小.Add(line);

            //#MEASURE 4/4を追加する
            renda_大.Add("#MEASURE 4/4");
            renda_小.Add("#MEASURE 4/4");

            bool rendaflag_小 = false;
            bool rendaflag_大 = false;

            //連打譜面のみの譜面を作成する
            while (counter < list.Count)
            {
                line = list[counter];
                //空白または小節しかなかった
                if (line.Length == 0 || line.Length == 1)
                {
                    //連打状態になっているか？
                    if (rendaflag_小)
                    {
                        renda_小.Add(line);
                    }
                    if (rendaflag_大)
                    {
                        renda_大.Add(line);
                    }
                    counter += 1;
                    continue;
                }
                //小節を変更する箇所を発見
                if (line.Substring(0, 2) == "#M")
                {
                    counter += 1;
                    if (line != "#M")
                    {
                        renda_大.Add(line);
                        renda_小.Add(line);
                    }
                    continue;
                }
                if (line.Substring(0, 2) == "#S")
                {
                    counter += 1;
                    continue;
                }
                if (line.Substring(0, 1) == "#")
                {
                    if (line.Substring(0, 3) == "#BP")
                    {
                        renda_大.Add(line);
                        renda_小.Add(line);
                    }
                    counter += 1;
                    continue;
                }
                //連打譜面ならフラグを用意
                if (line.Contains("5"))
                {
                    rendaflag_小 = true;
                }
                if (line.Contains("6"))
                {
                    rendaflag_大 = true;
                }
                //風船や連打片っぽを防ぐことが出来る
                if (!rendaflag_小 && !rendaflag_大)
                {
                    counter += 1;
                    continue;
                }
                //連打の途中譜面
                if (rendaflag_大)
                {
                    renda_大.Add(line);
                }
                else if (rendaflag_小)
                {
                    renda_小.Add(line);
                }

                if (line.Contains("8"))
                {
                    rendaflag_大 = false;
                    rendaflag_小 = false;
                }
                counter += 1;
            }

            //全体を最後に作成するやつ
            List<string>[] renda = new List<string>[2];
            renda[0] = renda_小;
            renda[1] = renda_大;
            return renda;
        }

        private int[] 拍数の取得(string str)
        {
            int[] hakusuu = new int[2];
            //最初は共通なので全然平気
            string line = str;

            //#MEASURE を削除
            line = line.Substring(line.Length - 3, 3);
            //分子
            hakusuu[0] = int.Parse(line.Substring(0, 1));
            //分母
            hakusuu[1] = int.Parse(line.Substring(2, 1));

            return hakusuu;
        }

        private float 小節ごとの最大演奏時間の取得(List<string> list,float nowbpm,int[] hakusuu)
        {
            //小節の最大演奏時間
            float byousuu;
            //60*拍子/テンポ

            //演奏時間の計算
            if (nowbpm == 0.0f)
            {
                byousuu = 0.0f;
            }
            else
            {
                byousuu = 60 * hakusuu[0]/ nowbpm;
            }
            return byousuu;
        }

        private int 連打数を自動計算をする(List<string>list)
        {
            const int 拍数ID = 1;

            int counter = 0;
            float renda_time = 0;
            int renda_total = 0;

            //初期BPMを取得する
            string nowbpmstr = this.BPMのデータ取得(list);
            float nowbpm = float.Parse(nowbpmstr);
            counter += 1;
            //初期拍数を取得する
            int[] hakusuu = this.拍数の取得(list[拍数ID]);
            counter += 1;

            string line = null;
            float ens演奏時間;

            bool flag_連打 = false;

            while(counter < list.Count)
            {
                line = list[counter];
                if(line.Substring(0,1) == "#")
                {
                    if(line.Substring(0,2) == "#M")
                    {
                        hakusuu = this.拍数の取得(line);
                    }
                    else if(line.Substring(0,2) == "#B")
                    {
                        nowbpmstr = line;
                        nowbpmstr = nowbpmstr.Substring(4, nowbpmstr.Length - 4);
                        nowbpm = float.Parse(nowbpmstr);
                    }
                    counter += 1;
                    continue;
                }
                //現在の演奏時間Maxを調べる
                ens演奏時間 = this.小節ごとの最大演奏時間の取得(list,nowbpm,hakusuu);
               

                string temp = null;


                //,までカットする
                for(int i = 0;  i < line.Length;++i)
                {
                    if(line.Substring(i,1) == ",")
                    {
                        break;
                    }
                    temp += line[i];
                }
                float rn = ens演奏時間 / temp.Length;

                //連打譜面を確認する
                for (int i = 0; i < temp.Length; ++i)
                {
                    if (flag_連打)
                    {
                        renda_time += rn;
                    }
                    if (temp.Substring(i, 1) == "8")
                    {
                        flag_連打 = false;
                    }
                    if (temp.Substring(i, 1) == "5" || temp.Substring(i, 1) == "6")
                    {
                        flag_連打 = true;
                    }
                }
                counter += 1;
            }
            float speed = 0;

            //連打数の確認
            if(this.checkBoxオート連打.Checked)
            {
                speed = 0.0625f;
            }
            else
            {
                speed = (float)this.numericUpDown連打数.Value;
            }
            float total = renda_time / speed;
            renda_total = (int)total;
            return renda_total;
        }
        private void checkBox連打数_CheckedChanged(object sender, EventArgs e)
        {
            if(this.checkBox連打数.CheckState == CheckState.Checked)
            {
                this.label連打数.Text = "1秒間の連打数";
            }
            else
            {
                this.label連打数.Text = "連打数";
            }
        }

        private void checkBoxオート連打_CheckedChanged(object sender, EventArgs e)
        {
            this.numericUpDown連打数.Value = (decimal)0.0625;
        }
    }
}
