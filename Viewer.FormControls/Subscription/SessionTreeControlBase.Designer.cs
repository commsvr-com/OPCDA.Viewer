namespace CAS.Lib.OPCClientControlsLib
{
  partial class SessionTreeControlBase
  {

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.m_SubscriptionTreeView = new CAS.Lib.OPCClientControlsLib.SubscriptionTreeView();
      this.SuspendLayout();
      // 
      // m_SubscriptionTreeView
      // 
      this.m_SubscriptionTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_SubscriptionTreeView.ImageIndex = 0;
      this.m_SubscriptionTreeView.Location = new System.Drawing.Point( 0, 0 );
      this.m_SubscriptionTreeView.Name = "m_SubscriptionTreeView";
      this.m_SubscriptionTreeView.SelectedImageIndex = 0;
      this.m_SubscriptionTreeView.ShowNodeToolTips = true;
      this.m_SubscriptionTreeView.Size = new System.Drawing.Size( 150, 150 );
      this.m_SubscriptionTreeView.TabIndex = 1;
      this.m_SubscriptionTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.m_SubscriptionTreeView_AfterSelect );
      this.m_SubscriptionTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler( this.m_SubscriptionTreeView_MouseDown );
      // 
      // SessionTreeControlBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add( this.m_SubscriptionTreeView );
      this.Name = "SessionTreeControlBase";
      this.ResumeLayout( false );
    }
    #endregion
    protected SubscriptionTreeView m_SubscriptionTreeView;
    private System.ComponentModel.IContainer components;
  }
}
