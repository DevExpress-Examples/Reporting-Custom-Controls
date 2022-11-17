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

Refer to the following document for information on **XRSwissQRBill** implementation: [How to Create a Custom DevExpress Report Control - Swiss QR Bill Implementation](./Examples/SwissQRBillExample/Readme.md).

## XRRoundLabel and XRRoundPanel

Refer to the following document for information on **XRRoundLabel and XRRoundPanel** implementation: [How to Create Controls with Rounded Corners](./DevExpress.XtraReports.CustomControls.RoundedControls/Readme.md).
