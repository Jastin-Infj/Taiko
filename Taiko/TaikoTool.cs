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
    public partial class 太鼓スコアシミュレータ : Form
    {
        private bool fileNameflag;
        //読み込んだ専用ファイル
        private List<string> fumen_全体 = new List<string>();
        //コースごとの読み込み文字列
        private List<string> fumen_鬼 = new List<string>();
        private List<string> fumen_難 = new List<string>();
        private List<string> fumen_普 = new List<string>();
        private List<string> fumen_簡 = new List<string>();


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
            openFileDialog.InitialDirectory = "C:/Users/Documents/";
            //ファイル名の種類(読み込み可能ファイルを選択)
            openFileDialog.Filter = "TJAファイル(*.tja)|*.tja";

            //ファイルダイアログのタイトル
            openFileDialog.Title = "TJAファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                this.textBoxTJAファイル読み込み.Text =  openFileDialog.FileName;
                this.fileNameflag = true;
            }
            else
            {
                this.fileNameflag = false;
            }
        }

        private void textBoxTJAファイル読み込み_TextChanged(object sender, EventArgs e)
        {
            if(!fileNameflag)
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
            //不正チェック用に文字列を代入させる
            this.TJAplayer3テキスト読み込み();
            if (!this.TJAplayer3テキスト不正チェック())
            {
                return;
            }
            this.Text = "OK";
        }

        private void TJAplayer3テキスト読み込み()
        {
            //ファイルを読み込み
            StreamReader sr = new StreamReader(textBoxTJAファイル読み込み.Text, Encoding.GetEncoding("Shift_JIS"));

            while(sr.Peek() >= 0)
            {
                //ファイルを1行ずつ読み込み
                string stBuffer = sr.ReadLine();
                this.fumen_全体.Add(stBuffer);
            }
            sr.Close();
        }

        private bool TJAplayer3テキスト不正チェック()
        {
            //チェックする要素
            //左から読み込む必要がある
            string[] search_要素 = { "COURSE:", "BPM:", "TITLE:", "#START", "#END" };
            //検索用カウンタ
            int i_カウンタ = 0;
            int flag = 0;

            while (i_カウンタ < fumen_全体.Count())
            {
                for(int i = 0;i < search_要素.Length;++i)
                {
                    if (this.fumen_全体[i_カウンタ] == search_要素[i])
                    {
                        //ビットで計算させる
                        flag += 1;
                        break;
                    }
                }
                ++i_カウンタ;
            }
            return flag == search_要素.Length;
        }
    }
}
