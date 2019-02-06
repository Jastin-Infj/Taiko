using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taiko
{
    public partial class 太鼓スコアシミュレータ : Form
    {
        public 太鼓スコアシミュレータ()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            　
        }

        private void 太鼓スコアシミュレータ_Load(object sender, EventArgs e)
        {
            //起動時は何も表示をしない
            label読み込み表示.Text = "";
        }

        private void buttonファイル読み込み_Click(object sender, EventArgs e)
        {
            //ファイルダイアログボックスを生成する
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //ファイル名の指定をする
            openFileDialog.FileName = "*.tja";
            //初めに開く時のファイルパスを選択する
            openFileDialog.InitialDirectory = "C:";
            //ファイル名の種類(読み込み可能ファイルを選択)
            openFileDialog.Filter = "TJAファイル(*.tja)|*.tja";

            //ファイルダイアログのタイトル
            openFileDialog.Title = "TJAファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                Console.WriteLine(openFileDialog.FileName);
            }

            label読み込み表示.Text = "";
        }

        private void textBoxTJAファイル読み込み_TextChanged(object sender, EventArgs e)
        {
            //TJAplayer3のファイル選択が可能にする
        }
    }
}
