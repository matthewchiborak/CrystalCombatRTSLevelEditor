namespace HCIDrawingAssignment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.modeLabel = new System.Windows.Forms.Label();
            this.freehandButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.squareButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.polygonButton = new System.Windows.Forms.Button();
            this.colourButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.selectedLabel = new System.Windows.Forms.Label();
            this.copyButton = new System.Windows.Forms.Button();
            this.cutButton = new System.Windows.Forms.Button();
            this.pasteButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.redoButton = new System.Windows.Forms.Button();
            this.pinButton = new System.Windows.Forms.Button();
            this.unpinButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.selectedColorBox = new System.Windows.Forms.PictureBox();
            this.canvasBox = new System.Windows.Forms.PictureBox();
            this.drawingSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.drawingOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.destroyWallButton = new System.Windows.Forms.Button();
            this.leftGuardButton = new System.Windows.Forms.Button();
            this.rightGuardButton = new System.Windows.Forms.Button();
            this.upGuardButton = new System.Windows.Forms.Button();
            this.downGuardButton = new System.Windows.Forms.Button();
            this.solidWallButton = new System.Windows.Forms.Button();
            this.startPointButton = new System.Windows.Forms.Button();
            this.keyButton = new System.Windows.Forms.Button();
            this.keyNameBox = new System.Windows.Forms.TextBox();
            this.goalButton = new System.Windows.Forms.Button();
            this.goalNameBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.removeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.xSizeBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ySizeBox = new System.Windows.Forms.NumericUpDown();
            this.generateButton = new System.Windows.Forms.Button();
            this.levelNumberBox = new System.Windows.Forms.NumericUpDown();
            this.gridCheckBox = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.TileBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xSizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNumberBox)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.modeLabel);
            this.flowLayoutPanel1.Controls.Add(this.freehandButton);
            this.flowLayoutPanel1.Controls.Add(this.lineButton);
            this.flowLayoutPanel1.Controls.Add(this.rectangleButton);
            this.flowLayoutPanel1.Controls.Add(this.squareButton);
            this.flowLayoutPanel1.Controls.Add(this.ellipseButton);
            this.flowLayoutPanel1.Controls.Add(this.circleButton);
            this.flowLayoutPanel1.Controls.Add(this.polygonButton);
            this.flowLayoutPanel1.Controls.Add(this.colourButton);
            this.flowLayoutPanel1.Controls.Add(this.selectButton);
            this.flowLayoutPanel1.Controls.Add(this.selectedLabel);
            this.flowLayoutPanel1.Controls.Add(this.copyButton);
            this.flowLayoutPanel1.Controls.Add(this.cutButton);
            this.flowLayoutPanel1.Controls.Add(this.pasteButton);
            this.flowLayoutPanel1.Controls.Add(this.undoButton);
            this.flowLayoutPanel1.Controls.Add(this.redoButton);
            this.flowLayoutPanel1.Controls.Add(this.pinButton);
            this.flowLayoutPanel1.Controls.Add(this.unpinButton);
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Controls.Add(this.loadButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(84, 529);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(3, 0);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(52, 13);
            this.modeLabel.TabIndex = 1;
            this.modeLabel.Text = "Freehand";
            // 
            // freehandButton
            // 
            this.freehandButton.Location = new System.Drawing.Point(3, 16);
            this.freehandButton.Name = "freehandButton";
            this.freehandButton.Size = new System.Drawing.Size(75, 23);
            this.freehandButton.TabIndex = 0;
            this.freehandButton.Text = "Freehand";
            this.freehandButton.UseVisualStyleBackColor = true;
            this.freehandButton.Click += new System.EventHandler(this.freehandButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(3, 45);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(75, 23);
            this.lineButton.TabIndex = 1;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Location = new System.Drawing.Point(3, 74);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(75, 23);
            this.rectangleButton.TabIndex = 2;
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // squareButton
            // 
            this.squareButton.Location = new System.Drawing.Point(3, 103);
            this.squareButton.Name = "squareButton";
            this.squareButton.Size = new System.Drawing.Size(75, 23);
            this.squareButton.TabIndex = 3;
            this.squareButton.Text = "Square";
            this.squareButton.UseVisualStyleBackColor = true;
            this.squareButton.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.Location = new System.Drawing.Point(3, 132);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(75, 23);
            this.ellipseButton.TabIndex = 4;
            this.ellipseButton.Text = "Ellipse";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.Location = new System.Drawing.Point(3, 161);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(75, 23);
            this.circleButton.TabIndex = 5;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // polygonButton
            // 
            this.polygonButton.Location = new System.Drawing.Point(3, 190);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(75, 23);
            this.polygonButton.TabIndex = 6;
            this.polygonButton.Text = "Polygon";
            this.polygonButton.UseVisualStyleBackColor = true;
            this.polygonButton.Click += new System.EventHandler(this.polygonButton_Click);
            // 
            // colourButton
            // 
            this.colourButton.Location = new System.Drawing.Point(3, 219);
            this.colourButton.Name = "colourButton";
            this.colourButton.Size = new System.Drawing.Size(52, 23);
            this.colourButton.TabIndex = 17;
            this.colourButton.Text = "Colour";
            this.colourButton.UseVisualStyleBackColor = true;
            this.colourButton.Click += new System.EventHandler(this.colourButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(3, 248);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(52, 23);
            this.selectButton.TabIndex = 7;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // selectedLabel
            // 
            this.selectedLabel.AutoSize = true;
            this.selectedLabel.Location = new System.Drawing.Point(61, 245);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(0, 13);
            this.selectedLabel.TabIndex = 19;
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(3, 277);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 8;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // cutButton
            // 
            this.cutButton.Location = new System.Drawing.Point(3, 306);
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(75, 23);
            this.cutButton.TabIndex = 9;
            this.cutButton.Text = "Cut";
            this.cutButton.UseVisualStyleBackColor = true;
            this.cutButton.Click += new System.EventHandler(this.cutButton_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(3, 335);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(75, 23);
            this.pasteButton.TabIndex = 10;
            this.pasteButton.Text = "Paste";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(3, 364);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(75, 23);
            this.undoButton.TabIndex = 11;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.Location = new System.Drawing.Point(3, 393);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(75, 23);
            this.redoButton.TabIndex = 12;
            this.redoButton.Text = "Redo";
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // pinButton
            // 
            this.pinButton.Location = new System.Drawing.Point(3, 422);
            this.pinButton.Name = "pinButton";
            this.pinButton.Size = new System.Drawing.Size(75, 23);
            this.pinButton.TabIndex = 13;
            this.pinButton.Text = "Pin";
            this.pinButton.UseVisualStyleBackColor = true;
            this.pinButton.Click += new System.EventHandler(this.pinButton_Click);
            // 
            // unpinButton
            // 
            this.unpinButton.Location = new System.Drawing.Point(3, 451);
            this.unpinButton.Name = "unpinButton";
            this.unpinButton.Size = new System.Drawing.Size(75, 23);
            this.unpinButton.TabIndex = 14;
            this.unpinButton.Text = "Unpin";
            this.unpinButton.UseVisualStyleBackColor = true;
            this.unpinButton.Click += new System.EventHandler(this.unpinButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(3, 480);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(3, 509);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 16;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // selectedColorBox
            // 
            this.selectedColorBox.BackColor = System.Drawing.Color.Black;
            this.selectedColorBox.Location = new System.Drawing.Point(218, 582);
            this.selectedColorBox.Name = "selectedColorBox";
            this.selectedColorBox.Size = new System.Drawing.Size(18, 16);
            this.selectedColorBox.TabIndex = 18;
            this.selectedColorBox.TabStop = false;
            this.selectedColorBox.Click += new System.EventHandler(this.selectedColorBox_Click);
            // 
            // canvasBox
            // 
            this.canvasBox.BackColor = System.Drawing.SystemColors.Window;
            this.canvasBox.Location = new System.Drawing.Point(102, 12);
            this.canvasBox.Name = "canvasBox";
            this.canvasBox.Size = new System.Drawing.Size(1149, 532);
            this.canvasBox.TabIndex = 1;
            this.canvasBox.TabStop = false;
            this.canvasBox.Click += new System.EventHandler(this.canvasBox_Click);
            this.canvasBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasBox_MouseDown);
            this.canvasBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasBox_MouseMove);
            this.canvasBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasBox_MouseUp);
            // 
            // drawingSaveDialog
            // 
            this.drawingSaveDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.drawingSaveDialog_FileOk);
            // 
            // drawingOpenDialog
            // 
            this.drawingOpenDialog.FileName = "openFileDialog1";
            this.drawingOpenDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.drawingOpenDialog_FileOk);
            // 
            // destroyWallButton
            // 
            this.destroyWallButton.Location = new System.Drawing.Point(84, 3);
            this.destroyWallButton.Name = "destroyWallButton";
            this.destroyWallButton.Size = new System.Drawing.Size(75, 23);
            this.destroyWallButton.TabIndex = 2;
            this.destroyWallButton.Text = "destroyWall";
            this.destroyWallButton.UseVisualStyleBackColor = true;
            this.destroyWallButton.Click += new System.EventHandler(this.destroyWallButton_Click);
            // 
            // leftGuardButton
            // 
            this.leftGuardButton.Location = new System.Drawing.Point(165, 3);
            this.leftGuardButton.Name = "leftGuardButton";
            this.leftGuardButton.Size = new System.Drawing.Size(75, 23);
            this.leftGuardButton.TabIndex = 3;
            this.leftGuardButton.Text = "leftGuard";
            this.leftGuardButton.UseVisualStyleBackColor = true;
            this.leftGuardButton.Click += new System.EventHandler(this.leftGuardButton_Click);
            // 
            // rightGuardButton
            // 
            this.rightGuardButton.Location = new System.Drawing.Point(246, 3);
            this.rightGuardButton.Name = "rightGuardButton";
            this.rightGuardButton.Size = new System.Drawing.Size(75, 23);
            this.rightGuardButton.TabIndex = 4;
            this.rightGuardButton.Text = "rightGuard";
            this.rightGuardButton.UseVisualStyleBackColor = true;
            this.rightGuardButton.Click += new System.EventHandler(this.rightGuardButton_Click);
            // 
            // upGuardButton
            // 
            this.upGuardButton.Location = new System.Drawing.Point(327, 3);
            this.upGuardButton.Name = "upGuardButton";
            this.upGuardButton.Size = new System.Drawing.Size(75, 23);
            this.upGuardButton.TabIndex = 5;
            this.upGuardButton.Text = "upGuard";
            this.upGuardButton.UseVisualStyleBackColor = true;
            this.upGuardButton.Click += new System.EventHandler(this.upGuardButton_Click);
            // 
            // downGuardButton
            // 
            this.downGuardButton.Location = new System.Drawing.Point(408, 3);
            this.downGuardButton.Name = "downGuardButton";
            this.downGuardButton.Size = new System.Drawing.Size(75, 23);
            this.downGuardButton.TabIndex = 6;
            this.downGuardButton.Text = "downGuard";
            this.downGuardButton.UseVisualStyleBackColor = true;
            this.downGuardButton.Click += new System.EventHandler(this.downGuardButton_Click);
            // 
            // solidWallButton
            // 
            this.solidWallButton.Location = new System.Drawing.Point(3, 3);
            this.solidWallButton.Name = "solidWallButton";
            this.solidWallButton.Size = new System.Drawing.Size(75, 23);
            this.solidWallButton.TabIndex = 7;
            this.solidWallButton.Text = "WORLDTILE";
            this.solidWallButton.UseVisualStyleBackColor = true;
            this.solidWallButton.Click += new System.EventHandler(this.solidWallButton_Click);
            // 
            // startPointButton
            // 
            this.startPointButton.Location = new System.Drawing.Point(489, 3);
            this.startPointButton.Name = "startPointButton";
            this.startPointButton.Size = new System.Drawing.Size(75, 23);
            this.startPointButton.TabIndex = 8;
            this.startPointButton.Text = "startPoint";
            this.startPointButton.UseVisualStyleBackColor = true;
            this.startPointButton.Click += new System.EventHandler(this.startPointButton_Click);
            // 
            // keyButton
            // 
            this.keyButton.Location = new System.Drawing.Point(570, 3);
            this.keyButton.Name = "keyButton";
            this.keyButton.Size = new System.Drawing.Size(75, 23);
            this.keyButton.TabIndex = 9;
            this.keyButton.Text = "key";
            this.keyButton.UseVisualStyleBackColor = true;
            this.keyButton.Click += new System.EventHandler(this.keyButton_Click);
            // 
            // keyNameBox
            // 
            this.keyNameBox.Location = new System.Drawing.Point(651, 3);
            this.keyNameBox.Name = "keyNameBox";
            this.keyNameBox.Size = new System.Drawing.Size(100, 20);
            this.keyNameBox.TabIndex = 10;
            this.keyNameBox.Text = "keyNameBox";
            // 
            // goalButton
            // 
            this.goalButton.Location = new System.Drawing.Point(3, 32);
            this.goalButton.Name = "goalButton";
            this.goalButton.Size = new System.Drawing.Size(75, 23);
            this.goalButton.TabIndex = 11;
            this.goalButton.Text = "goal";
            this.goalButton.UseVisualStyleBackColor = true;
            this.goalButton.Click += new System.EventHandler(this.goalButton_Click);
            // 
            // goalNameBox
            // 
            this.goalNameBox.Location = new System.Drawing.Point(84, 32);
            this.goalNameBox.Name = "goalNameBox";
            this.goalNameBox.Size = new System.Drawing.Size(100, 20);
            this.goalNameBox.TabIndex = 12;
            this.goalNameBox.Text = "goalNameBox";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.solidWallButton);
            this.flowLayoutPanel2.Controls.Add(this.destroyWallButton);
            this.flowLayoutPanel2.Controls.Add(this.leftGuardButton);
            this.flowLayoutPanel2.Controls.Add(this.rightGuardButton);
            this.flowLayoutPanel2.Controls.Add(this.upGuardButton);
            this.flowLayoutPanel2.Controls.Add(this.downGuardButton);
            this.flowLayoutPanel2.Controls.Add(this.startPointButton);
            this.flowLayoutPanel2.Controls.Add(this.keyButton);
            this.flowLayoutPanel2.Controls.Add(this.keyNameBox);
            this.flowLayoutPanel2.Controls.Add(this.goalButton);
            this.flowLayoutPanel2.Controls.Add(this.goalNameBox);
            this.flowLayoutPanel2.Controls.Add(this.removeButton);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.xSizeBox);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.ySizeBox);
            this.flowLayoutPanel2.Controls.Add(this.generateButton);
            this.flowLayoutPanel2.Controls.Add(this.levelNumberBox);
            this.flowLayoutPanel2.Controls.Add(this.gridCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.clearButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(353, 550);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(808, 83);
            this.flowLayoutPanel2.TabIndex = 15;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(190, 32);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 18;
            this.removeButton.Text = "remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Width";
            // 
            // xSizeBox
            // 
            this.xSizeBox.Location = new System.Drawing.Point(312, 32);
            this.xSizeBox.Maximum = new decimal(new int[] {
            115,
            0,
            0,
            0});
            this.xSizeBox.Name = "xSizeBox";
            this.xSizeBox.Size = new System.Drawing.Size(120, 20);
            this.xSizeBox.TabIndex = 20;
            this.xSizeBox.ValueChanged += new System.EventHandler(this.xSizeBox_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Height";
            // 
            // ySizeBox
            // 
            this.ySizeBox.Location = new System.Drawing.Point(482, 32);
            this.ySizeBox.Maximum = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.ySizeBox.Name = "ySizeBox";
            this.ySizeBox.Size = new System.Drawing.Size(120, 20);
            this.ySizeBox.TabIndex = 21;
            this.ySizeBox.ValueChanged += new System.EventHandler(this.ySizeBox_ValueChanged);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(608, 32);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(111, 20);
            this.generateButton.TabIndex = 17;
            this.generateButton.Text = "Generate File";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // levelNumberBox
            // 
            this.levelNumberBox.Location = new System.Drawing.Point(3, 61);
            this.levelNumberBox.Name = "levelNumberBox";
            this.levelNumberBox.Size = new System.Drawing.Size(120, 20);
            this.levelNumberBox.TabIndex = 19;
            // 
            // gridCheckBox
            // 
            this.gridCheckBox.AutoSize = true;
            this.gridCheckBox.Location = new System.Drawing.Point(129, 61);
            this.gridCheckBox.Name = "gridCheckBox";
            this.gridCheckBox.Size = new System.Drawing.Size(82, 17);
            this.gridCheckBox.TabIndex = 22;
            this.gridCheckBox.Text = "Display Grid";
            this.gridCheckBox.UseVisualStyleBackColor = true;
            this.gridCheckBox.CheckedChanged += new System.EventHandler(this.gridCheckBox_CheckedChanged);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(217, 61);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 23;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(73, 639);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(1013, 82);
            this.outputBox.TabIndex = 16;
            // 
            // TileBox
            // 
            this.TileBox.AllowDrop = true;
            this.TileBox.FormattingEnabled = true;
            this.TileBox.Location = new System.Drawing.Point(91, 579);
            this.TileBox.Name = "TileBox";
            this.TileBox.Size = new System.Drawing.Size(121, 21);
            this.TileBox.TabIndex = 17;
            this.TileBox.SelectedIndexChanged += new System.EventHandler(this.TileBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 562);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tile Type:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 733);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TileBox);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.canvasBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.selectedColorBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xSizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNumberBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button freehandButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button squareButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button polygonButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button cutButton;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.Button pinButton;
        private System.Windows.Forms.Button unpinButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button colourButton;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.PictureBox canvasBox;
        private System.Windows.Forms.PictureBox selectedColorBox;
        private System.Windows.Forms.SaveFileDialog drawingSaveDialog;
        private System.Windows.Forms.OpenFileDialog drawingOpenDialog;
        private System.Windows.Forms.Label selectedLabel;
        private System.Windows.Forms.Button destroyWallButton;
        private System.Windows.Forms.Button leftGuardButton;
        private System.Windows.Forms.Button rightGuardButton;
        private System.Windows.Forms.Button upGuardButton;
        private System.Windows.Forms.Button downGuardButton;
        private System.Windows.Forms.Button solidWallButton;
        private System.Windows.Forms.Button startPointButton;
        private System.Windows.Forms.Button keyButton;
        private System.Windows.Forms.TextBox keyNameBox;
        private System.Windows.Forms.Button goalButton;
        private System.Windows.Forms.TextBox goalNameBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.NumericUpDown levelNumberBox;
        private System.Windows.Forms.NumericUpDown ySizeBox;
        private System.Windows.Forms.NumericUpDown xSizeBox;
        private System.Windows.Forms.CheckBox gridCheckBox;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ComboBox TileBox;
        private System.Windows.Forms.Label label3;
    }
}

