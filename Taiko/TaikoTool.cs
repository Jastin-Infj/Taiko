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
    struct Score
    {
        public int 最大コンボ数;
        public int スコア計算結果;
    };

    public partial class 太鼓スコアシミュレータ : Form
    {
        private bool fileNameflag;
        //読み込んだ専用ファイル
        private List<string> line_全譜面 = new List<string>();
        private List<string> line_鬼譜面 = new List<string>();


        public 太鼓スコアシミュレータ()
        {
            InitializeComponent();
        }
        private void 太鼓スコアシミュレータ_Load(object sender, EventArgs e)
        {
            fileNameflag = false;
        }

        private void buttonファイル読み込み_Click(object sender, EventArgs e)
        {
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
            if (!fileNameflag)
            {
                this.Text = "ここにファイル名を入力";
            }
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

            Score score = new Score();
            score.スコア計算結果 = 0;
            score.最大コンボ数 = コンボ数の計算();
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
    }
}
