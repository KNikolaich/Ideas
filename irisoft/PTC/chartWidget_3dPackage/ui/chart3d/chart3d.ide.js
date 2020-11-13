TW.IDE.Widgets.chart3d = function () {
    this.widgetIconUrl = function() {
        return "../Common/extensions/chartWidget_3dPackage/ui/chart3d/images/chart3d.ide.png";
    };

    this.widgetProperties = function () {
        return {
            name : "chart3d",
            description : "A simple example of Widget creation.",
            category : ["Common"],
            properties : {
                DisplayText: {
                    baseType: "STRING",
                    defaultValue: "Hello, Awesome User!",
                    isBindingTarget: true
                }
            } 
        }
    };

    this.renderHtml = function () {
        var mytext = this.getProperty('chart3d Property');

        var config = {
            text: mytext
        }
        
        var widgetTemplate = _.template(
            '<p>'+
            '<h5>название</h6>' +
            '<div class="widget-content widget-chart3d">' +
            '<span class="DisplayText"><%- text %></span>' +
            '</div>'
        );

        return widgetTemplate(config);
    };

    this.afterSetProperty = function (name, value) {
        return true;
    };
};