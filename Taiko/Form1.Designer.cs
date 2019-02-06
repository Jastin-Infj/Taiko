namespace Taiko
{
    partial class 太鼓スコアシミュレータ
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton旧基準 = new System.Windows.Forms.RadioButton();
            this.radioButton新基準 = new System.Windows.Forms.RadioButton();
            this.panelスコア配点モード = new System.Windows.Forms.Panel();
            this.labelスコア配点モード = new System.Windows.Forms.Label();
            this.textBoxTJAファイル読み込み = new System.Windows.Forms.TextBox();
            this.buttonファイル読み込み = new System.Windows.Forms.Button();
            this.label読み込み表示 = new System.Windows.Forms.Label();
            this.panelスコア配点モード.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton旧基準
            // 
            this.radioButton旧基準.AutoSize = true;
            this.radioButton旧基準.Location = new System.Drawing.Point(19, 70);
            this.radioButton旧基準.Name = "radioButton旧基準";
            this.radioButton旧基準.Size = new System.Drawing.Size(59, 16);
            this.radioButton旧基準.TabIndex = 0;
            this.radioButton旧基準.TabStop = true;
            this.radioButton旧基準.Text = "旧基準";
            this.radioButton旧基準.UseVisualStyleBackColor = true;
            this.radioButton旧基準.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton新基準
            // 
            this.radioButton新基準.AutoSize = true;
            this.radioButton新基準.Location = new System.Drawing.Point(124, 70);
            this.radioButton新基準.Name = "radioButton新基準";
            this.radioButton新基準.Size = new System.Drawing.Size(59, 16);
            this.radioButton新基準.TabIndex = 1;
            this.radioButton新基準.TabStop = true;
            this.radioButton新基準.Text = "新基準";
            this.radioButton新基準.UseVisualStyleBackColor = true;
            // 
            // panelスコア配点モード
            // 
            this.panelスコア配点モード.Controls.Add(this.labelスコア配点モード);
            this.panelスコア配点モード.Controls.Add(this.radioButton旧基準);
            this.panelスコア配点モード.Controls.Add(this.radioButton新基準);
            this.panelスコア配点モード.Location = new System.Drawing.Point(12, 12);
            this.panelスコア配点モード.Name = "panelスコア配点モード";
            this.panelスコア配点モード.Size = new System.Drawing.Size(200, 94);
            this.panelスコア配点モード.TabIndex = 2;
            // 
            // labelスコア配点モード
            // 
            this.labelスコア配点モード.AutoSize = true;
            this.labelスコア配点モード.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelスコア配点モード.Location = new System.Drawing.Point(17, 20);
            this.labelスコア配点モード.Name = "labelスコア配点モード";
            this.labelスコア配点モード.Size = new System.Drawing.Size(166, 24);
            this.labelスコア配点モード.TabIndex = 3;
            this.labelスコア配点モード.Text = "スコア配点モード";
            // 
            // textBoxTJAファイル読み込み
            // 
            this.textBoxTJAファイル読み込み.Location = new System.Drawing.Point(12, 147);
            this.textBoxTJAファイル読み込み.Name = "textBoxTJAファイル読み込み";
            this.textBoxTJAファイル読み込み.Size = new System.Drawing.Size(200, 19);
            this.textBoxTJAファイル読み込み.TabIndex = 3;
            this.textBoxTJAファイル読み込み.Text = "ファイル名をここに入力";
            this.textBoxTJAファイル読み込み.TextChanged += new System.EventHandler(this.textBoxTJAファイル読み込み_TextChanged);
            // 
            // buttonファイル読み込み
            // 
            this.buttonファイル読み込み.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonファイル読み込み.Location = new System.Drawing.Point(234, 145);
            this.buttonファイル読み込み.Name = "buttonファイル読み込み";
            this.buttonファイル読み込み.Size = new System.Drawing.Size(75, 23);
            this.buttonファイル読み込み.TabIndex = 4;
            this.buttonファイル読み込み.Text = "読み込み";
            this.buttonファイル読み込み.UseVisualStyleBackColor = false;
            this.buttonファイル読み込み.Click += new System.EventHandler(this.buttonファイル読み込み_Click);
            // 
            // label読み込み表示
            // 
            this.label読み込み表示.AutoSize = true;
            this.label読み込み表示.Location = new System.Drawing.Point(86, 184);
            this.label読み込み表示.Name = "label読み込み表示";
            this.label読み込み表示.Size = new System.Drawing.Size(63, 12);
            this.label読み込み表示.TabIndex = 6;
            this.label読み込み表示.Text = "読み込み中";
            // 
            // 太鼓スコアシミュレータ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 302);
            this.Controls.Add(this.label読み込み表示);
            this.Controls.Add(this.buttonファイル読み込み);
            this.Controls.Add(this.textBoxTJAファイル読み込み);
            this.Controls.Add(this.panelスコア配点モード);
            this.Name = "太鼓スコアシミュレータ";
            this.Text = "太鼓シミュレータ";
            this.Load += new System.EventHandler(this.太鼓スコアシミュレータ_Load);
            this.panelスコア配点モード.ResumeLayout(false);
            this.panelスコア配点モード.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton旧基準;
        private System.Windows.Forms.RadioButton radioButton新基準;
        private System.Windows.Forms.Panel panelスコア配点モード;
        private System.Windows.Forms.Label labelスコア配点モード;
        private System.Windows.Forms.TextBox textBoxTJAファイル読み込み;
        private System.Windows.Forms.Button buttonファイル読み込み;
        private System.Windows.Forms.Label label読み込み表示;
    }
}

