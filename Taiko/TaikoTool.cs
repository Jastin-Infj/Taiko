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
        private List<string> lines = new List<string>();


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
            this.TJAplayer3テキスト読み込み();
        }

        private void TJAplayer3テキスト読み込み()
        {
            //ファイルを読み込み
            StreamReader sr = new StreamReader(textBoxTJAファイル読み込み.Text, Encoding.GetEncoding("Shift_JIS"));

            while(sr.Peek() >= 0)
            {
                //ファイルを1行ずつ読み込み
                string stBuffer = sr.ReadLine();
                this.lines.Add(stBuffer);
            }
            sr.Close();
        }

        private bool TJAplayer3テキスト不正チェック()
        {
            //タイトルがない

            //BPMがない

            //COURSE:の記述がない

            //#STARTがない

            //#ENDがない

            return true;
        }
    }
}
