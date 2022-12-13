function customizeToolbox(s, e, shortTypeName, fullTypeName, inheritClass, displayName, defaultVal) {
    var controlsFactory = e.ControlsFactory;
    var numberInfo = controlsFactory.getPropertyInfo("XRLabel", "Angle");
    var radiusSerializableInfo = $.extend({}, numberInfo, {
        propertyName: "borderCornerRadius",
        modelName: "@BorderCornerRadius",
        displayName: "Border Corner Radius",
        localizationId: "",
        defaultVal
    });
    var controlsFactory = e.ControlsFactory;
    var classInfo = controlsFactory.getControlInfo(inheritClass);

    class RoundedControlSurface extends classInfo.surfaceType {
        constructor(control, context) {
            super(control, context);
            let borderCss = this.borderCss;
            this.borderCss = ko.pureComputed(() => {
                return {
                    ...borderCss(),
                    'borderRadius': control.borderCornerRadius()
                };
            });
        }
    }

    var roundedControlInfo = controlsFactory.inheritControl(inheritClass, {
        surfaceType: RoundedControlSurface,
        defaultVal: {
            "@ControlType": fullTypeName,
            "@TextAlignment": "MiddleCenter",
            "@BorderWidth": "2"
        },
        displayName,
        info: [radiusSerializableInfo],
        popularProperties: ["borderCornerRadius"]
    });

    controlsFactory.registerControl(shortTypeName, roundedControlInfo);
    s.GetPropertyInfo(shortTypeName, "BorderWidth").defaultVal = 2;
    s.GetPropertyInfo(shortTypeName, "BorderDashStyle").defaultVal = "Solid";
    s.GetPropertyInfo(shortTypeName, "Borders").defaultVal = "All";
    s.GetPropertyInfo(shortTypeName, "Borders").visible = false;
    s.GetPropertyInfo(shortTypeName, "BorderDashStyle").visible = false;
    controlsFactory.setExpressionBinding(shortTypeName, "BorderCornerRadius", controlsFactory._beforePrintPrintOnPage);
    s.AddToPropertyGrid("Appearance", radiusSerializableInfo);
}