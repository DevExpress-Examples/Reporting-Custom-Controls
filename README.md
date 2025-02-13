<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/274919437/22.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T906638)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to Create a Custom DevExpress Report Control

## Report Control Development Steps

To create a new report control, do the following:

1. Choose a base class. If you cannot find a suitable control to derive from, inherit a component from the [XRControl](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.UI.XRControl) class.

2. Create the component's object model. Specify a set of properties and related attributes that determine how  properties are serialized and displayed in the Property grid.

3. Create component designers for Visual Studio and the End User Designer. Designers determine the component's appearance and behavior at design time. Add attributes as necessary.

4. Choose the base class for the component's “brick” - such as the brick that the base class creates. However, if the component inherits from the [XRControl](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.UI.XRControl) class, there are two options - select [VisualBrick](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.VisualBrick) as the brick's base class if you require a simple brick or [PanelBrick](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.PanelBrick) if you need a container. 

5. Specify how the component creates its "brick" and map the component's properties to the brick's characteristics.

6. Implement the **BrickExporter** class to render the "brick". Override the methods used for drawing and export.

## XRSwissQRBill

Refer to the following document for information on **XRSwissQRBill** implementation: [How to Create a Custom DevExpress Report Control - Swiss QR Bill Implementation](./DevExpress.XtraReports.CustomControls.SwissQRBill/Readme.md).

## XRRoundLabel and XRRoundPanel

Refer to the following document for information on **XRRoundLabel and XRRoundPanel** implementation: [How to Create Controls with Rounded Corners](./DevExpress.XtraReports.CustomControls.RoundedControls/Readme.md).

## Examples

### WinForms

Run the sample project to invoke the WinForms End-User Report Designer with a toolbox that contains the [XRSwissQRBill](./DevExpress.XtraReports.CustomControls.SwissQRBill/SwissQRBill/XRSwissQRBill.cs), [XRRoundLabel](./DevExpress.XtraReports.CustomControls.RoundedControls/Label/XRRoundLabel.cs) and [XRRoundPanel](./DevExpress.XtraReports.CustomControls.RoundedControls/Panel/XRRoundPanel.cs) controls.

The project is in the [Examples/CustomControlExample.Win](./Examples/CustomControlExample.Win/) folder. File to review: [Program.cs](./Examples/CustomControlExample.Win/Program.cs).

### ASP.NET Core

Run the sample project to invoke the ASP.NET Core End-User Report Designer with a toolbox that contains the [XRRoundLabel](./DevExpress.XtraReports.CustomControls.RoundedControls/Label/XRRoundLabel.cs), and [XRRoundPanel](./DevExpress.XtraReports.CustomControls.RoundedControls/Panel/XRRoundPanel.cs) controls.

The project is in the [Examples/CustomControlExample.AspNetCore](./Examples/CustomControlExample.AspNetCore/) folder. Files to review: [Startup.cs](./Examples/CustomControlExample.AspNetCore/Startup.cs) and [Designer.cshtml](./Examples/CustomControlExample.AspNetCore/Views/Home/Designer.cshtml).

## Files to Review

### XRSwissQRBill

- [XRSwissQRBill.cs](/DevExpress.XtraReports.CustomControls.SwissQRBill/SwissQRBill/XRSwissQRBill.cs)
- [SwissQRBillCustomControl.cs](/DevExpress.XtraReports.CustomControls.SwissQRBill/SwissQRBillCustomControl.cs)
- [SwissQRBillBrick.cs](/DevExpress.XtraReports.CustomControls.SwissQRBill/SwissQRBill/SwissQRBillBrick.cs)
- [CustomControlToolBoxRegistrator.cs](/DevExpress.XtraReports.CustomControls.Design/CustomControlToolBoxRegistrator.cs)
- [XRSwissQRBillDesignerActionList.cs](/DevExpress.XtraReports.CustomControls.Design/XRSwissQRBillDesignerActionList.cs)
- [TypeConverters.cs](/DevExpress.XtraReports.CustomControls.SwissQRBill/SwissQRBill/TypeConverters.cs)

### XRRoundLabel and XRRoundPanel

- [XRRoundLabel.cs](/DevExpress.XtraReports.CustomControls.RoundedControls/Label/XRRoundLabel.cs)
- [RoundLabelBrick.cs](/DevExpress.XtraReports.CustomControls.RoundedControls/Label/RoundLabelBrick.cs)
- [RoundLabelBrickExporter.cs](/DevExpress.XtraReports.CustomControls.RoundedControls/Label/RoundLabelBrickExporter.cs)
- [XRRoundPanel.cs](/DevExpress.XtraReports.CustomControls.RoundedControls/Panel/XRRoundPanel.cs)
- [RoundPanelBrick.cs](/DevExpress.XtraReports.CustomControls.RoundedControls/Panel/RoundPanelBrick.cs)
- [RoundLabelBrickExporter.cs](/DevExpress.XtraReports.CustomControls.RoundedControls/Panel/RoundPanelBrickExporter.cs)
- [RoundedBorderPaintHelper.cs](./DevExpress.XtraReports.CustomControls.RoundedControls/RoundedBorderPaintHelper.cs)
- [RoundedCustomControl.cs](./DevExpress.XtraReports.CustomControls.RoundedControls/RoundedCustomControl.cs)
- [CustomControlToolBoxRegistrator.cs](./DevExpress.XtraReports.CustomControls.Design/CustomControlToolBoxRegistrator.cs)

## Documentation

- [Use Custom Controls](https://docs.devexpress.com/XtraReports/2607/detailed-guide-to-devexpress-reporting/use-report-controls/use-custom-controls)

## More Examples

- [Create a Custom Numeric Label](https://github.com/DevExpress-Examples/Reporting-Create-Custom-Numeric-Label)
- [Create a Custom Progress Bar Control](https://github.com/DevExpress-Examples/Reporting_how-to-create-custom-report-controls-e57)
- [Add a Custom Control to the End-User Report Designer Toolbox (WPF)](https://github.com/DevExpress-Examples/Reporting_wpf-end-user-report-designer-how-to-register-a-custom-control-in-the-designers-t416384)
- [Custom Report Control in the Web End User Designer Toolbox (ASP.NET Web Forms)](https://github.com/DevExpress-Examples/Reporting_aspxreportdesigner-how-to-register-a-custom-control-in-the-designers-toolbox-t209289)
- [Custom Report Control in the Web End User Designer Toolbox (ASP.NET MVC)](https://github.com/DevExpress-Examples/Reporting-AspNetMvc-Create-Custom-Control)
- [Custom Report Control in the Web End User Designer Toolbox in ASP.NET Core Application](https://github.com/DevExpress-Examples/Reporting-AspNetCore-Create-Custom-Control) 
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=Reporting-Custom-Controls&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=Reporting-Custom-Controls&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
