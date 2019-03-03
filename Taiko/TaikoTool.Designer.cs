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
            this.buttonスコア計算 = new System.Windows.Forms.Button();
            this.panel天井スコア = new System.Windows.Forms.Panel();
            this.labelスコアINIT = new System.Windows.Forms.Label();
            this.label理想スコア = new System.Windows.Forms.Label();
            this.numericUpDown風船回数 = new System.Windows.Forms.NumericUpDown();
            this.label風船回数 = new System.Windows.Forms.Label();
            this.numericUpDown風船連打数 = new System.Windows.Forms.NumericUpDown();
            this.label風船連打数 = new System.Windows.Forms.Label();
            this.label連打数 = new System.Windows.Forms.Label();
            this.numericUpDown連打数 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown天井スコア = new System.Windows.Forms.NumericUpDown();
            this.label理想天井スコア = new System.Windows.Forms.Label();
            this.checkBox連打数 = new System.Windows.Forms.CheckBox();
            this.checkBox風船回数自動 = new System.Windows.Forms.CheckBox();
            this.checkBox連打込みの天井スコア = new System.Windows.Forms.CheckBox();
            this.checkBox小数点を四捨五入する = new System.Windows.Forms.CheckBox();
            this.panel譜面制作対象 = new System.Windows.Forms.Panel();
            this.radioButton裏譜面その他 = new System.Windows.Forms.RadioButton();
            this.radioButtonおに譜面 = new System.Windows.Forms.RadioButton();
            this.radioButtonむずかしい譜面 = new System.Windows.Forms.RadioButton();
            this.radioButtonふつう譜面 = new System.Windows.Forms.RadioButton();
            this.radioButtonかんたん譜面 = new System.Windows.Forms.RadioButton();
            this.checkBoxCOURSEがない = new System.Windows.Forms.CheckBox();
            this.label天井スコアの表示 = new System.Windows.Forms.Label();
            this.checkBoxオート連打 = new System.Windows.Forms.CheckBox();
            this.panelスコア配点モード.SuspendLayout();
            this.panel天井スコア.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown風船回数)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown風船連打数)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown連打数)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown天井スコア)).BeginInit();
            this.panel譜面制作対象.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton旧基準
            // 
            this.radioButton旧基準.AutoSize = true;
            this.radioButton旧基準.Location = new System.Drawing.Point(32, 105);
            this.radioButton旧基準.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButton旧基準.Name = "radioButton旧基準";
            this.radioButton旧基準.Size = new System.Drawing.Size(87, 22);
            this.radioButton旧基準.TabIndex = 0;
            this.radioButton旧基準.Text = "旧基準";
            this.radioButton旧基準.UseVisualStyleBackColor = true;
            // 
            // radioButton新基準
            // 
            this.radioButton新基準.AutoSize = true;
            this.radioButton新基準.Checked = true;
            this.radioButton新基準.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radioButton新基準.Location = new System.Drawing.Point(207, 105);
            this.radioButton新基準.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButton新基準.Name = "radioButton新基準";
            this.radioButton新基準.Size = new System.Drawing.Size(87, 22);
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
            this.panelスコア配点モード.Location = new System.Drawing.Point(20, 18);
            this.panelスコア配点モード.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panelスコア配点モード.Name = "panelスコア配点モード";
            this.panelスコア配点モード.Size = new System.Drawing.Size(333, 141);
            this.panelスコア配点モード.TabIndex = 2;
            // 
            // labelスコア配点モード
            // 
            this.labelスコア配点モード.AutoSize = true;
            this.labelスコア配点モード.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelスコア配点モード.Location = new System.Drawing.Point(28, 30);
            this.labelスコア配点モード.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelスコア配点モード.Name = "labelスコア配点モード";
            this.labelスコア配点モード.Size = new System.Drawing.Size(249, 36);
            this.labelスコア配点モード.TabIndex = 3;
            this.labelスコア配点モード.Text = "スコア配点モード";
            // 
            // textBoxTJAファイル読み込み
            // 
            this.textBoxTJAファイル読み込み.Location = new System.Drawing.Point(20, 220);
            this.textBoxTJAファイル読み込み.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxTJAファイル読み込み.Name = "textBoxTJAファイル読み込み";
            this.textBoxTJAファイル読み込み.Size = new System.Drawing.Size(331, 25);
            this.textBoxTJAファイル読み込み.TabIndex = 3;
            this.textBoxTJAファイル読み込み.Text = "ファイル名をここに入力";
            this.textBoxTJAファイル読み込み.TextChanged += new System.EventHandler(this.textBoxTJAファイル読み込み_TextChanged);
            // 
            // buttonファイル読み込み
            // 
            this.buttonファイル読み込み.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonファイル読み込み.Location = new System.Drawing.Point(390, 218);
            this.buttonファイル読み込み.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonファイル読み込み.Name = "buttonファイル読み込み";
            this.buttonファイル読み込み.Size = new System.Drawing.Size(125, 34);
            this.buttonファイル読み込み.TabIndex = 4;
            this.buttonファイル読み込み.Text = "読み込み";
            this.buttonファイル読み込み.UseVisualStyleBackColor = false;
            this.buttonファイル読み込み.Click += new System.EventHandler(this.buttonファイル読み込み_Click);
            // 
            // buttonスコア計算
            // 
            this.buttonスコア計算.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonスコア計算.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonスコア計算.Location = new System.Drawing.Point(116, 226);
            this.buttonスコア計算.Name = "buttonスコア計算";
            this.buttonスコア計算.Size = new System.Drawing.Size(105, 34);
            this.buttonスコア計算.TabIndex = 5;
            this.buttonスコア計算.Text = "スコア計算";
            this.buttonスコア計算.UseVisualStyleBackColor = false;
            this.buttonスコア計算.Click += new System.EventHandler(this.buttonスコア計算_Click);
            // 
            // panel天井スコア
            // 
            this.panel天井スコア.Controls.Add(this.labelスコアINIT);
            this.panel天井スコア.Controls.Add(this.label理想スコア);
            this.panel天井スコア.Controls.Add(this.numericUpDown風船回数);
            this.panel天井スコア.Controls.Add(this.label風船回数);
            this.panel天井スコア.Controls.Add(this.numericUpDown風船連打数);
            this.panel天井スコア.Controls.Add(this.label風船連打数);
            this.panel天井スコア.Controls.Add(this.label連打数);
            this.panel天井スコア.Controls.Add(this.numericUpDown連打数);
            this.panel天井スコア.Controls.Add(this.numericUpDown天井スコア);
            this.panel天井スコア.Controls.Add(this.label理想天井スコア);
            this.panel天井スコア.Controls.Add(this.buttonスコア計算);
            this.panel天井スコア.Location = new System.Drawing.Point(20, 252);
            this.panel天井スコア.Name = "panel天井スコア";
            this.panel天井スコア.Size = new System.Drawing.Size(350, 275);
            this.panel天井スコア.TabIndex = 6;
            // 
            // labelスコアINIT
            // 
            this.labelスコアINIT.AutoSize = true;
            this.labelスコアINIT.Location = new System.Drawing.Point(204, 180);
            this.labelスコアINIT.Name = "labelスコアINIT";
            this.labelスコアINIT.Size = new System.Drawing.Size(0, 18);
            this.labelスコアINIT.TabIndex = 25;
            // 
            // label理想スコア
            // 
            this.label理想スコア.AutoSize = true;
            this.label理想スコア.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label理想スコア.Location = new System.Drawing.Point(32, 180);
            this.label理想スコア.Name = "label理想スコア";
            this.label理想スコア.Size = new System.Drawing.Size(0, 33);
            this.label理想スコア.TabIndex = 24;
            // 
            // numericUpDown風船回数
            // 
            this.numericUpDown風船回数.Location = new System.Drawing.Point(198, 135);
            this.numericUpDown風船回数.Name = "numericUpDown風船回数";
            this.numericUpDown風船回数.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown風船回数.TabIndex = 15;
            this.numericUpDown風船回数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label風船回数
            // 
            this.label風船回数.AutoSize = true;
            this.label風船回数.Location = new System.Drawing.Point(62, 135);
            this.label風船回数.Name = "label風船回数";
            this.label風船回数.Size = new System.Drawing.Size(80, 18);
            this.label風船回数.TabIndex = 14;
            this.label風船回数.Text = "風船回数";
            // 
            // numericUpDown風船連打数
            // 
            this.numericUpDown風船連打数.Location = new System.Drawing.Point(198, 97);
            this.numericUpDown風船連打数.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown風船連打数.Name = "numericUpDown風船連打数";
            this.numericUpDown風船連打数.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown風船連打数.TabIndex = 13;
            this.numericUpDown風船連打数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label風船連打数
            // 
            this.label風船連打数.AutoSize = true;
            this.label風船連打数.Location = new System.Drawing.Point(46, 97);
            this.label風船連打数.Name = "label風船連打数";
            this.label風船連打数.Size = new System.Drawing.Size(98, 18);
            this.label風船連打数.TabIndex = 12;
            this.label風船連打数.Text = "風船連打数";
            // 
            // label連打数
            // 
            this.label連打数.AutoSize = true;
            this.label連打数.Location = new System.Drawing.Point(62, 63);
            this.label連打数.Name = "label連打数";
            this.label連打数.Size = new System.Drawing.Size(62, 18);
            this.label連打数.TabIndex = 11;
            this.label連打数.Text = "連打数";
            // 
            // numericUpDown連打数
            // 
            this.numericUpDown連打数.DecimalPlaces = 6;
            this.numericUpDown連打数.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown連打数.Location = new System.Drawing.Point(198, 61);
            this.numericUpDown連打数.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown連打数.Name = "numericUpDown連打数";
            this.numericUpDown連打数.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown連打数.TabIndex = 10;
            this.numericUpDown連打数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown天井スコア
            // 
            this.numericUpDown天井スコア.Location = new System.Drawing.Point(198, 20);
            this.numericUpDown天井スコア.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown天井スコア.Name = "numericUpDown天井スコア";
            this.numericUpDown天井スコア.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown天井スコア.TabIndex = 9;
            this.numericUpDown天井スコア.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label理想天井スコア
            // 
            this.label理想天井スコア.AutoSize = true;
            this.label理想天井スコア.Location = new System.Drawing.Point(35, 27);
            this.label理想天井スコア.Name = "label理想天井スコア";
            this.label理想天井スコア.Size = new System.Drawing.Size(120, 18);
            this.label理想天井スコア.TabIndex = 8;
            this.label理想天井スコア.Text = "理想天井スコア";
            // 
            // checkBox連打数
            // 
            this.checkBox連打数.AutoSize = true;
            this.checkBox連打数.Checked = true;
            this.checkBox連打数.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox連打数.Location = new System.Drawing.Point(376, 315);
            this.checkBox連打数.Name = "checkBox連打数";
            this.checkBox連打数.Size = new System.Drawing.Size(148, 22);
            this.checkBox連打数.TabIndex = 7;
            this.checkBox連打数.Text = "連打数おすすめ";
            this.checkBox連打数.UseVisualStyleBackColor = true;
            this.checkBox連打数.CheckedChanged += new System.EventHandler(this.checkBox連打数_CheckedChanged);
            // 
            // checkBox風船回数自動
            // 
            this.checkBox風船回数自動.AutoSize = true;
            this.checkBox風船回数自動.Checked = true;
            this.checkBox風船回数自動.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox風船回数自動.Location = new System.Drawing.Point(376, 352);
            this.checkBox風船回数自動.Name = "checkBox風船回数自動";
            this.checkBox風船回数自動.Size = new System.Drawing.Size(142, 22);
            this.checkBox風船回数自動.TabIndex = 8;
            this.checkBox風船回数自動.Text = "風船回数自動";
            this.checkBox風船回数自動.UseVisualStyleBackColor = true;
            // 
            // checkBox連打込みの天井スコア
            // 
            this.checkBox連打込みの天井スコア.AutoSize = true;
            this.checkBox連打込みの天井スコア.Checked = true;
            this.checkBox連打込みの天井スコア.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox連打込みの天井スコア.Location = new System.Drawing.Point(376, 272);
            this.checkBox連打込みの天井スコア.Name = "checkBox連打込みの天井スコア";
            this.checkBox連打込みの天井スコア.Size = new System.Drawing.Size(195, 22);
            this.checkBox連打込みの天井スコア.TabIndex = 9;
            this.checkBox連打込みの天井スコア.Text = "連打込みの天井スコア";
            this.checkBox連打込みの天井スコア.UseVisualStyleBackColor = true;
            // 
            // checkBox小数点を四捨五入する
            // 
            this.checkBox小数点を四捨五入する.AutoSize = true;
            this.checkBox小数点を四捨五入する.Location = new System.Drawing.Point(377, 387);
            this.checkBox小数点を四捨五入する.Name = "checkBox小数点を四捨五入する";
            this.checkBox小数点を四捨五入する.Size = new System.Drawing.Size(203, 22);
            this.checkBox小数点を四捨五入する.TabIndex = 10;
            this.checkBox小数点を四捨五入する.Text = "小数点を四捨五入する";
            this.checkBox小数点を四捨五入する.UseVisualStyleBackColor = true;
            // 
            // panel譜面制作対象
            // 
            this.panel譜面制作対象.Controls.Add(this.radioButton裏譜面その他);
            this.panel譜面制作対象.Controls.Add(this.radioButtonおに譜面);
            this.panel譜面制作対象.Controls.Add(this.radioButtonむずかしい譜面);
            this.panel譜面制作対象.Controls.Add(this.radioButtonふつう譜面);
            this.panel譜面制作対象.Controls.Add(this.radioButtonかんたん譜面);
            this.panel譜面制作対象.Location = new System.Drawing.Point(20, 170);
            this.panel譜面制作対象.Name = "panel譜面制作対象";
            this.panel譜面制作対象.Size = new System.Drawing.Size(623, 43);
            this.panel譜面制作対象.TabIndex = 11;
            // 
            // radioButton裏譜面その他
            // 
            this.radioButton裏譜面その他.AutoSize = true;
            this.radioButton裏譜面その他.Location = new System.Drawing.Point(429, 3);
            this.radioButton裏譜面その他.Name = "radioButton裏譜面その他";
            this.radioButton裏譜面その他.Size = new System.Drawing.Size(176, 22);
            this.radioButton裏譜面その他.TabIndex = 4;
            this.radioButton裏譜面その他.Text = "裏譜面またはその他";
            this.radioButton裏譜面その他.UseVisualStyleBackColor = true;
            // 
            // radioButtonおに譜面
            // 
            this.radioButtonおに譜面.AutoSize = true;
            this.radioButtonおに譜面.Checked = true;
            this.radioButtonおに譜面.Location = new System.Drawing.Point(356, 3);
            this.radioButtonおに譜面.Name = "radioButtonおに譜面";
            this.radioButtonおに譜面.Size = new System.Drawing.Size(62, 22);
            this.radioButtonおに譜面.TabIndex = 3;
            this.radioButtonおに譜面.TabStop = true;
            this.radioButtonおに譜面.Text = "おに";
            this.radioButtonおに譜面.UseVisualStyleBackColor = true;
            // 
            // radioButtonむずかしい譜面
            // 
            this.radioButtonむずかしい譜面.AutoSize = true;
            this.radioButtonむずかしい譜面.Location = new System.Drawing.Point(237, 3);
            this.radioButtonむずかしい譜面.Name = "radioButtonむずかしい譜面";
            this.radioButtonむずかしい譜面.Size = new System.Drawing.Size(106, 22);
            this.radioButtonむずかしい譜面.TabIndex = 2;
            this.radioButtonむずかしい譜面.Text = "むずかしい";
            this.radioButtonむずかしい譜面.UseVisualStyleBackColor = true;
            // 
            // radioButtonふつう譜面
            // 
            this.radioButtonふつう譜面.AutoSize = true;
            this.radioButtonふつう譜面.Location = new System.Drawing.Point(143, 3);
            this.radioButtonふつう譜面.Name = "radioButtonふつう譜面";
            this.radioButtonふつう譜面.Size = new System.Drawing.Size(73, 22);
            this.radioButtonふつう譜面.TabIndex = 1;
            this.radioButtonふつう譜面.Text = "ふつう";
            this.radioButtonふつう譜面.UseVisualStyleBackColor = true;
            // 
            // radioButtonかんたん譜面
            // 
            this.radioButtonかんたん譜面.AutoSize = true;
            this.radioButtonかんたん譜面.Location = new System.Drawing.Point(32, 3);
            this.radioButtonかんたん譜面.Name = "radioButtonかんたん譜面";
            this.radioButtonかんたん譜面.Size = new System.Drawing.Size(92, 22);
            this.radioButtonかんたん譜面.TabIndex = 0;
            this.radioButtonかんたん譜面.Text = "かんたん";
            this.radioButtonかんたん譜面.UseVisualStyleBackColor = true;
            // 
            // checkBoxCOURSEがない
            // 
            this.checkBoxCOURSEがない.AutoSize = true;
            this.checkBoxCOURSEがない.Location = new System.Drawing.Point(551, 352);
            this.checkBoxCOURSEがない.Name = "checkBoxCOURSEがない";
            this.checkBoxCOURSEがない.Size = new System.Drawing.Size(152, 22);
            this.checkBoxCOURSEがない.TabIndex = 12;
            this.checkBoxCOURSEがない.Text = "COURSE:がない";
            this.checkBoxCOURSEがない.UseVisualStyleBackColor = true;
            // 
            // label天井スコアの表示
            // 
            this.label天井スコアの表示.AutoSize = true;
            this.label天井スコアの表示.Location = new System.Drawing.Point(377, 432);
            this.label天井スコアの表示.Name = "label天井スコアの表示";
            this.label天井スコアの表示.Size = new System.Drawing.Size(0, 18);
            this.label天井スコアの表示.TabIndex = 13;
            // 
            // checkBoxオート連打
            // 
            this.checkBoxオート連打.AutoSize = true;
            this.checkBoxオート連打.Location = new System.Drawing.Point(551, 314);
            this.checkBoxオート連打.Name = "checkBoxオート連打";
            this.checkBoxオート連打.Size = new System.Drawing.Size(145, 22);
            this.checkBoxオート連打.TabIndex = 14;
            this.checkBoxオート連打.Text = "オートの連打数";
            this.checkBoxオート連打.UseVisualStyleBackColor = true;
            this.checkBoxオート連打.CheckedChanged += new System.EventHandler(this.checkBoxオート連打_CheckedChanged);
            // 
            // 太鼓スコアシミュレータ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 539);
            this.Controls.Add(this.checkBoxオート連打);
            this.Controls.Add(this.label天井スコアの表示);
            this.Controls.Add(this.checkBoxCOURSEがない);
            this.Controls.Add(this.panel譜面制作対象);
            this.Controls.Add(this.checkBox小数点を四捨五入する);
            this.Controls.Add(this.checkBox連打込みの天井スコア);
            this.Controls.Add(this.checkBox風船回数自動);
            this.Controls.Add(this.checkBox連打数);
            this.Controls.Add(this.panel天井スコア);
            this.Controls.Add(this.buttonファイル読み込み);
            this.Controls.Add(this.textBoxTJAファイル読み込み);
            this.Controls.Add(this.panelスコア配点モード);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "太鼓スコアシミュレータ";
            this.Text = "太鼓シミュレータ";
            this.Load += new System.EventHandler(this.太鼓スコアシミュレータ_Load);
            this.panelスコア配点モード.ResumeLayout(false);
            this.panelスコア配点モード.PerformLayout();
            this.panel天井スコア.ResumeLayout(false);
            this.panel天井スコア.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown風船回数)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown風船連打数)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown連打数)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown天井スコア)).EndInit();
            this.panel譜面制作対象.ResumeLayout(false);
            this.panel譜面制作対象.PerformLayout();
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
        private System.Windows.Forms.Button buttonスコア計算;
        private System.Windows.Forms.Panel panel天井スコア;
        private System.Windows.Forms.Label label理想天井スコア;
        private System.Windows.Forms.NumericUpDown numericUpDown天井スコア;
        private System.Windows.Forms.Label label連打数;
        private System.Windows.Forms.NumericUpDown numericUpDown連打数;
        private System.Windows.Forms.CheckBox checkBox連打数;
        private System.Windows.Forms.NumericUpDown numericUpDown風船回数;
        private System.Windows.Forms.Label label風船回数;
        private System.Windows.Forms.NumericUpDown numericUpDown風船連打数;
        private System.Windows.Forms.Label label風船連打数;
        private System.Windows.Forms.CheckBox checkBox風船回数自動;
        private System.Windows.Forms.Label label理想スコア;
        private System.Windows.Forms.CheckBox checkBox連打込みの天井スコア;
        private System.Windows.Forms.CheckBox checkBox小数点を四捨五入する;
        private System.Windows.Forms.Label labelスコアINIT;
        private System.Windows.Forms.Panel panel譜面制作対象;
        private System.Windows.Forms.RadioButton radioButton裏譜面その他;
        private System.Windows.Forms.RadioButton radioButtonおに譜面;
        private System.Windows.Forms.RadioButton radioButtonむずかしい譜面;
        private System.Windows.Forms.RadioButton radioButtonふつう譜面;
        private System.Windows.Forms.RadioButton radioButtonかんたん譜面;
        private System.Windows.Forms.CheckBox checkBoxCOURSEがない;
        private System.Windows.Forms.Label label天井スコアの表示;
        private System.Windows.Forms.CheckBox checkBoxオート連打;
    }
}

