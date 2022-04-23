using YeRoBattle.Engine.Models;
using YeRoBattle.BattleField.Engine;

namespace YeRoBattle.BattleField
{
    partial class MapControl
    {

        public MapControl(GameDetails gameDetails)
        {
            InitializeComponent();
            BuildMap(gameDetails);
        }

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

        private void BuildMap(GameDetails gameDetails) 
        {
            new MapCreator().Create(this, gameDetails);
        } 

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(756, 488);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
