namespace TPReservaLab.Views
{
    partial class frmEditReserva
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            cbxLaboratorio = new ComboBox();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            cbxTipoReserva = new ComboBox();
            cbxProfesor = new ComboBox();
            cbxAsignatura = new ComboBox();
            cbxComision = new ComboBox();
            cbxCarrera = new ComboBox();
            gbCuatrimestral = new GroupBox();
            dtpFechaFinCuatri = new DateTimePicker();
            label7 = new Label();
            rdbQuincenal = new RadioButton();
            rdbSemanal = new RadioButton();
            gbEventual = new GroupBox();
            label10 = new Label();
            txtCantSemanas = new TextBox();
            btnGuardar = new Button();
            txtObservaciones = new TextBox();
            label11 = new Label();
            gbCuatrimestral.SuspendLayout();
            gbEventual.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 117);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 5;
            label3.Text = "Laboratorio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 83);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "Fecha fin";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 46);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 3;
            label1.Text = "Fecha inicio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(421, 80);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 8;
            label4.Text = "Asignatura";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(434, 40);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 7;
            label5.Text = "Profesor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 154);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 6;
            label6.Text = "Tipo de Reserva";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(440, 154);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 10;
            label8.Text = "Carrera";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(427, 117);
            label9.Name = "label9";
            label9.Size = new Size(58, 15);
            label9.TabIndex = 9;
            label9.Text = "Comisión";
            // 
            // cbxLaboratorio
            // 
            cbxLaboratorio.FormattingEnabled = true;
            cbxLaboratorio.Location = new Point(133, 114);
            cbxLaboratorio.Name = "cbxLaboratorio";
            cbxLaboratorio.Size = new Size(200, 23);
            cbxLaboratorio.TabIndex = 11;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.CustomFormat = "ddd, d MMMM yyyy HH:mm";
            dtpFechaInicio.Format = DateTimePickerFormat.Custom;
            dtpFechaInicio.Location = new Point(133, 40);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(228, 23);
            dtpFechaInicio.TabIndex = 12;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.CustomFormat = "ddd, d MMMM yyyy HH:mm";
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.Location = new Point(133, 77);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(228, 23);
            dtpFechaFin.TabIndex = 13;
            // 
            // cbxTipoReserva
            // 
            cbxTipoReserva.FormattingEnabled = true;
            cbxTipoReserva.Location = new Point(134, 151);
            cbxTipoReserva.Name = "cbxTipoReserva";
            cbxTipoReserva.Size = new Size(162, 23);
            cbxTipoReserva.TabIndex = 14;
            // 
            // cbxProfesor
            // 
            cbxProfesor.FormattingEnabled = true;
            cbxProfesor.Location = new Point(491, 37);
            cbxProfesor.Name = "cbxProfesor";
            cbxProfesor.Size = new Size(200, 23);
            cbxProfesor.TabIndex = 15;
            // 
            // cbxAsignatura
            // 
            cbxAsignatura.FormattingEnabled = true;
            cbxAsignatura.Location = new Point(491, 77);
            cbxAsignatura.Name = "cbxAsignatura";
            cbxAsignatura.Size = new Size(200, 23);
            cbxAsignatura.TabIndex = 16;
            // 
            // cbxComision
            // 
            cbxComision.FormattingEnabled = true;
            cbxComision.Location = new Point(491, 114);
            cbxComision.Name = "cbxComision";
            cbxComision.Size = new Size(200, 23);
            cbxComision.TabIndex = 17;
            // 
            // cbxCarrera
            // 
            cbxCarrera.FormattingEnabled = true;
            cbxCarrera.Location = new Point(491, 151);
            cbxCarrera.Name = "cbxCarrera";
            cbxCarrera.Size = new Size(200, 23);
            cbxCarrera.TabIndex = 18;
            // 
            // gbCuatrimestral
            // 
            gbCuatrimestral.Controls.Add(dtpFechaFinCuatri);
            gbCuatrimestral.Controls.Add(label7);
            gbCuatrimestral.Controls.Add(rdbQuincenal);
            gbCuatrimestral.Controls.Add(rdbSemanal);
            gbCuatrimestral.Location = new Point(48, 201);
            gbCuatrimestral.Name = "gbCuatrimestral";
            gbCuatrimestral.Size = new Size(333, 122);
            gbCuatrimestral.TabIndex = 19;
            gbCuatrimestral.TabStop = false;
            gbCuatrimestral.Text = "Cuatrimestral";
            gbCuatrimestral.Visible = false;
            // 
            // dtpFechaFinCuatri
            // 
            dtpFechaFinCuatri.CustomFormat = "ddd, d MMMM yyyy HH:mm";
            dtpFechaFinCuatri.Format = DateTimePickerFormat.Custom;
            dtpFechaFinCuatri.Location = new Point(85, 64);
            dtpFechaFinCuatri.Name = "dtpFechaFinCuatri";
            dtpFechaFinCuatri.Size = new Size(228, 23);
            dtpFechaFinCuatri.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 70);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 13;
            label7.Text = "Fecha fin";
            // 
            // rdbQuincenal
            // 
            rdbQuincenal.AutoSize = true;
            rdbQuincenal.Location = new Point(115, 32);
            rdbQuincenal.Name = "rdbQuincenal";
            rdbQuincenal.Size = new Size(79, 19);
            rdbQuincenal.TabIndex = 1;
            rdbQuincenal.TabStop = true;
            rdbQuincenal.Text = "Quincenal";
            rdbQuincenal.UseVisualStyleBackColor = true;
            // 
            // rdbSemanal
            // 
            rdbSemanal.AutoSize = true;
            rdbSemanal.Location = new Point(28, 32);
            rdbSemanal.Name = "rdbSemanal";
            rdbSemanal.Size = new Size(70, 19);
            rdbSemanal.TabIndex = 0;
            rdbSemanal.TabStop = true;
            rdbSemanal.Text = "Semanal";
            rdbSemanal.UseVisualStyleBackColor = true;
            // 
            // gbEventual
            // 
            gbEventual.Controls.Add(label10);
            gbEventual.Controls.Add(txtCantSemanas);
            gbEventual.Location = new Point(48, 201);
            gbEventual.Name = "gbEventual";
            gbEventual.Size = new Size(313, 96);
            gbEventual.TabIndex = 20;
            gbEventual.TabStop = false;
            gbEventual.Text = "Eventual";
            gbEventual.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 38);
            label10.Name = "label10";
            label10.Size = new Size(120, 15);
            label10.TabIndex = 14;
            label10.Text = "Cantidad de semanas";
            // 
            // txtCantSemanas
            // 
            txtCantSemanas.Location = new Point(141, 35);
            txtCantSemanas.Name = "txtCantSemanas";
            txtCantSemanas.Size = new Size(100, 23);
            txtCantSemanas.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(599, 348);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(92, 32);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(491, 188);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(200, 135);
            txtObservaciones.TabIndex = 20;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(401, 240);
            label11.Name = "label11";
            label11.Size = new Size(84, 15);
            label11.TabIndex = 21;
            label11.Text = "Observaciones";
            // 
            // frmEditReserva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 424);
            Controls.Add(label11);
            Controls.Add(gbEventual);
            Controls.Add(gbCuatrimestral);
            Controls.Add(txtObservaciones);
            Controls.Add(btnGuardar);
            Controls.Add(cbxCarrera);
            Controls.Add(cbxComision);
            Controls.Add(cbxAsignatura);
            Controls.Add(cbxProfesor);
            Controls.Add(cbxTipoReserva);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(cbxLaboratorio);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmEditReserva";
            Text = "Reserva";
            gbCuatrimestral.ResumeLayout(false);
            gbCuatrimestral.PerformLayout();
            gbEventual.ResumeLayout(false);
            gbEventual.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label9;
        private ComboBox cbxLaboratorio;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private ComboBox cbxTipoReserva;
        private ComboBox cbxProfesor;
        private ComboBox cbxAsignatura;
        private ComboBox cbxComision;
        private ComboBox cbxCarrera;
        private GroupBox gbCuatrimestral;
        private DateTimePicker dtpFechaFinCuatri;
        private Label label7;
        private RadioButton rdbQuincenal;
        private RadioButton rdbSemanal;
        private GroupBox gbEventual;
        private Label label10;
        private TextBox txtCantSemanas;
        private Button btnGuardar;
        private TextBox txtObservaciones;
        private Label label11;
    }
}