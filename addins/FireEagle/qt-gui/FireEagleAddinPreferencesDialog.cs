// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Synapse.Addins.FireEagle {
    using System;
    using Qyoto;
    
    
    public partial class FireEagleAddinPreferencesDialog : QDialog {
        
        protected QWidget widget_2;
        
        protected QLabel logoLabel;
        
        protected QStackedWidget stackedWidget;
        
        protected QWidget page;
        
        protected QLabel label_2;
        
        protected QPushButton setupButton;
        
        protected QLabel waitLabel1;
        
        protected QWidget page_3;
        
        protected QLabel label_3;
        
        protected QWidget widget;
        
        protected QLineEdit urlLineEdit;
        
        protected QLabel label_5;
        
        protected QPushButton continueButton;
        
        protected QLabel waitLabel2;
        
        protected QWidget page_2;
        
        protected QLabel label;
        
        protected QLabel locationLabel;
        
        protected QPushButton reauthorizeButton;
        
        protected QDialogButtonBox buttonBox;
        
        protected void SetupUi() {
            base.ObjectName = "FireEagleAddinPreferencesDialog";
            this.Geometry = new QRect(0, 0, 495, 390);
            this.WindowTitle = "FireEagle Preferences";
            QVBoxLayout verticalLayout;
            verticalLayout = new QVBoxLayout(this);
            this.widget_2 = new QWidget(this);
            this.widget_2.ObjectName = "widget_2";
            QHBoxLayout horizontalLayout_3;
            horizontalLayout_3 = new QHBoxLayout(this.widget_2);
            this.logoLabel = new QLabel(this.widget_2);
            this.logoLabel.ObjectName = "logoLabel";
            this.logoLabel.MinimumSize = new QSize(16, 0);
            this.logoLabel.Text = "";
            this.logoLabel.Alignment = ((global::Qyoto.Qyoto.GetCPPEnumValue("Qt", "AlignRight") | global::Qyoto.Qyoto.GetCPPEnumValue("Qt", "AlignTrailing")) | global::Qyoto.Qyoto.GetCPPEnumValue("Qt", "AlignVCenter"));
            horizontalLayout_3.AddWidget(this.logoLabel);
            verticalLayout.AddWidget(this.widget_2);
            this.stackedWidget = new QStackedWidget(this);
            this.stackedWidget.ObjectName = "stackedWidget";
            this.stackedWidget.CurrentIndex = 2;
            verticalLayout.AddWidget(this.stackedWidget);
            this.page = new QWidget(this.stackedWidget);
            this.page.ObjectName = "page";
            QVBoxLayout verticalLayout_2;
            verticalLayout_2 = new QVBoxLayout(this.page);
            QSpacerItem verticalSpacer_2;
            verticalSpacer_2 = new QSpacerItem(20, 40, QSizePolicy.Policy.Minimum, QSizePolicy.Policy.Expanding);
            verticalLayout_2.AddItem(verticalSpacer_2);
            this.label_2 = new QLabel(this.page);
            this.label_2.ObjectName = "label_2";
            this.label_2.Text = "The FireEagle addin is currently disabled. Click the button below to configure it.";
            this.label_2.Alignment = ((global::Qyoto.Qyoto.GetCPPEnumValue("Qt", "AlignLeading") | global::Qyoto.Qyoto.GetCPPEnumValue("Qt", "AlignLeft")) | global::Qyoto.Qyoto.GetCPPEnumValue("Qt", "AlignVCenter"));
            this.label_2.WordWrap = true;
            verticalLayout_2.AddWidget(this.label_2);
            QHBoxLayout horizontalLayout;
            horizontalLayout = new QHBoxLayout();
            verticalLayout_2.AddLayout(horizontalLayout);
            QSpacerItem horizontalSpacer;
            horizontalSpacer = new QSpacerItem(40, 20, QSizePolicy.Policy.Expanding, QSizePolicy.Policy.Minimum);
            horizontalLayout.AddItem(horizontalSpacer);
            this.setupButton = new QPushButton(this.page);
            this.setupButton.ObjectName = "setupButton";
            this.setupButton.StyleSheet = "font-size: 15pt;\nfont-weight: bold;";
            this.setupButton.Text = "Set Up FireEagle";
            horizontalLayout.AddWidget(this.setupButton);
            QSpacerItem horizontalSpacer_2;
            horizontalSpacer_2 = new QSpacerItem(40, 20, QSizePolicy.Policy.Expanding, QSizePolicy.Policy.Minimum);
            horizontalLayout.AddItem(horizontalSpacer_2);
            this.waitLabel1 = new QLabel(this.page);
            this.waitLabel1.ObjectName = "waitLabel1";
            this.waitLabel1.Text = "Please Wait...";
            verticalLayout_2.AddWidget(this.waitLabel1);
            QSpacerItem verticalSpacer;
            verticalSpacer = new QSpacerItem(20, 40, QSizePolicy.Policy.Minimum, QSizePolicy.Policy.Expanding);
            verticalLayout_2.AddItem(verticalSpacer);
            this.stackedWidget.AddWidget(this.page);
            this.page_3 = new QWidget(this.stackedWidget);
            this.page_3.ObjectName = "page_3";
            QVBoxLayout verticalLayout_3;
            verticalLayout_3 = new QVBoxLayout(this.page_3);
            verticalLayout_3.Spacing = 6;
            this.label_3 = new QLabel(this.page_3);
            this.label_3.ObjectName = "label_3";
            this.label_3.Text = "Synapse is launching your web browser to complete the FireEagle setup process.\n\nIf your browser does not open automatically, copy and paste the following URL into your browser's address bar:";
            this.label_3.WordWrap = true;
            verticalLayout_3.AddWidget(this.label_3);
            this.widget = new QWidget(this.page_3);
            this.widget.ObjectName = "widget";
            QVBoxLayout verticalLayout_5;
            verticalLayout_5 = new QVBoxLayout(this.widget);
            this.urlLineEdit = new QLineEdit(this.widget);
            this.urlLineEdit.ObjectName = "urlLineEdit";
            this.urlLineEdit.ReadOnly = true;
            verticalLayout_5.AddWidget(this.urlLineEdit);
            verticalLayout_3.AddWidget(this.widget);
            this.label_5 = new QLabel(this.page_3);
            this.label_5.ObjectName = "label_5";
            this.label_5.Text = "Follow the instructions on the web page, then return here and click Continue.";
            this.label_5.WordWrap = true;
            verticalLayout_3.AddWidget(this.label_5);
            QHBoxLayout horizontalLayout_2;
            horizontalLayout_2 = new QHBoxLayout();
            verticalLayout_3.AddLayout(horizontalLayout_2);
            QSpacerItem horizontalSpacer3;
            horizontalSpacer3 = new QSpacerItem(40, 20, QSizePolicy.Policy.Expanding, QSizePolicy.Policy.Minimum);
            horizontalLayout_2.AddItem(horizontalSpacer3);
            this.continueButton = new QPushButton(this.page_3);
            this.continueButton.ObjectName = "continueButton";
            this.continueButton.StyleSheet = "font-size: 15pt;\nfont-weight: bold;";
            this.continueButton.Text = "Continue";
            horizontalLayout_2.AddWidget(this.continueButton);
            QSpacerItem horizontalSpacer_23;
            horizontalSpacer_23 = new QSpacerItem(40, 20, QSizePolicy.Policy.Expanding, QSizePolicy.Policy.Minimum);
            horizontalLayout_2.AddItem(horizontalSpacer_23);
            this.waitLabel2 = new QLabel(this.page_3);
            this.waitLabel2.ObjectName = "waitLabel2";
            this.waitLabel2.Text = "Please Wait...";
            verticalLayout_3.AddWidget(this.waitLabel2);
            QSpacerItem verticalSpacer_3;
            verticalSpacer_3 = new QSpacerItem(20, 40, QSizePolicy.Policy.Minimum, QSizePolicy.Policy.Expanding);
            verticalLayout_3.AddItem(verticalSpacer_3);
            this.stackedWidget.AddWidget(this.page_3);
            this.page_2 = new QWidget(this.stackedWidget);
            this.page_2.ObjectName = "page_2";
            QVBoxLayout verticalLayout_4;
            verticalLayout_4 = new QVBoxLayout(this.page_2);
            this.label = new QLabel(this.page_2);
            this.label.ObjectName = "label";
            QSizePolicy label_sizePolicy;
            label_sizePolicy = new QSizePolicy(QSizePolicy.Policy.Preferred, QSizePolicy.Policy.Minimum);
            label_sizePolicy.SetVerticalStretch(0);
            label_sizePolicy.SetHorizontalStretch(0);
            label_sizePolicy.SetHeightForWidth(this.label.SizePolicy.HasHeightForWidth());
            this.label.SizePolicy = label_sizePolicy;
            this.label.Text = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0//EN\" \"http://www.w3.org/TR/REC-html40/strict.dtd\">\n<html><head><meta name=\"qrichtext\" content=\"1\" /><style type=\"text/css\">\np, li { white-space: pre-wrap; }\n</style></head><body style=\" font-family:'Bitstream Vera Sans'; font-size:9pt; font-weight:400; font-style:normal;\">\n<p style=\" margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px;\"><span style=\" font-size:12pt; font-weight:600;\">FireEagle thinks you are at:</span></p></body></html>";
            this.label.WordWrap = true;
            verticalLayout_4.AddWidget(this.label);
            this.locationLabel = new QLabel(this.page_2);
            this.locationLabel.ObjectName = "locationLabel";
            QSizePolicy locationLabel_sizePolicy;
            locationLabel_sizePolicy = new QSizePolicy(QSizePolicy.Policy.Preferred, QSizePolicy.Policy.Minimum);
            locationLabel_sizePolicy.SetVerticalStretch(0);
            locationLabel_sizePolicy.SetHorizontalStretch(0);
            locationLabel_sizePolicy.SetHeightForWidth(this.locationLabel.SizePolicy.HasHeightForWidth());
            this.locationLabel.SizePolicy = locationLabel_sizePolicy;
            this.locationLabel.Text = "";
            verticalLayout_4.AddWidget(this.locationLabel);
            QSpacerItem verticalSpacer_4;
            verticalSpacer_4 = new QSpacerItem(20, 40, QSizePolicy.Policy.Minimum, QSizePolicy.Policy.Expanding);
            verticalLayout_4.AddItem(verticalSpacer_4);
            QHBoxLayout horizontalLayout_4;
            horizontalLayout_4 = new QHBoxLayout();
            verticalLayout_4.AddLayout(horizontalLayout_4);
            this.reauthorizeButton = new QPushButton(this.page_2);
            this.reauthorizeButton.ObjectName = "reauthorizeButton";
            this.reauthorizeButton.Text = "Re-authorize";
            horizontalLayout_4.AddWidget(this.reauthorizeButton);
            QSpacerItem horizontalSpacer_4;
            horizontalSpacer_4 = new QSpacerItem(40, 20, QSizePolicy.Policy.Expanding, QSizePolicy.Policy.Minimum);
            horizontalLayout_4.AddItem(horizontalSpacer_4);
            this.stackedWidget.AddWidget(this.page_2);
            this.buttonBox = new QDialogButtonBox(this);
            this.buttonBox.ObjectName = "buttonBox";
            this.buttonBox.Orientation = Qt.Orientation.Horizontal;
            this.buttonBox.StandardButtons = global::Qyoto.Qyoto.GetCPPEnumValue("QDialogButtonBox", "Close");
            verticalLayout.AddWidget(this.buttonBox);
            QObject.Connect(buttonBox, Qt.SIGNAL("accepted()"), this, Qt.SLOT("accept()"));
            QObject.Connect(buttonBox, Qt.SIGNAL("rejected()"), this, Qt.SLOT("reject()"));
            QMetaObject.ConnectSlotsByName(this);
        }
    }
}
