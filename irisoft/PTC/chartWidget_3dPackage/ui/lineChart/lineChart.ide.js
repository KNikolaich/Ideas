/*global Encoder,TW */

TW.IDE.Widgets.lineChart = function () {

    // max could be much higher
    this.MAX_SERIES = 8;
    this.widgetIconUrl = function () {
        //widget
        //return  "../Common/thingworx/widgets/lineChart/images/lineChart.ide.png";
        //extension
        return  "../Common/extensions/chartWidget_ExtensionPackage/ui/lineChart/images/lineChart.ide.png";
    };

    this.widgetProperties = function () {
        var properties = {
            'name': 'Line Chart',
            'description': 'Displays a line chart',
            'category': ['Data', 'Charts'],
            'supportsLabel': false,
	        'supportsAutoResize': true,
            'borderWidth': 1,
            'defaultBindingTargetProperty': 'Data',
            'properties': {
                'SingleDataSource': {
                    'description': 'Use a Single Data Source for All Series',
                    'defaultValue': true,
                    'baseType': 'BOOLEAN',
                    'isVisible': true
                },
                'NumberOfSeries': {
                    'description': 'Desired number of series in this chart',
                    'defaultValue': 1,
                    'baseType': 'NUMBER',
                    'isVisible': true
                },
                'Data': {
                    'description': 'Data source',
                    'isBindingTarget': true,
                    'isEditable': false,
                    'baseType': 'INFOTABLE',
                    'warnIfNotBoundAsTarget': false
                },
                'ChartTitle': {
                    'description': 'Chart Title',
                    'baseType': 'STRING',
                    'isBindingTarget': true,
                    'defaultValue': '',
                    'isLocalizable': true
                },
                'ShowAxisLabels':{
                    'description': 'Show Major axis labels',
                    'baseType': 'BOOLEAN',
                    'defaultValue': true
                },
                'X-AxisLabel': {
                    'description': 'Label for X Axis',
                    'defaultValue': 'X Axis',
                    'baseType': 'STRING',
                    'isLocalizable': true
                },
                'Y-AxisLabel': {
                    'description': 'Label for Y Axis',
                    'defaultValue': 'Y Axis',
                    'baseType': 'STRING',
                    'isLocalizable': true
                },
                'LabelAngle':{
                    'description': 'Longer labels in chart fit diagonally',
                    'defaultValue': 0,
                    'baseType': 'INTEGER'
                },
                'Interpolation':{
                    'description': 'Line Smoothness',
                    'defaultValue': 'linear',
                    'baseType': 'String',
                    'selectOptions': [
                        { value: 'linear', text: 'Linear' },
                        { value: 'basis', text: 'Smooth' },
                        { value: 'cardinal', text: 'Less Smooth' },
                        { value: 'step-before', text: 'Stepped' }
                    ]
                },
                'Duration':{
                    'description': 'Length of chart animation',
                    'defaultValue':500,
                    'baseType':'NUMBER'
                },
                'ChartBodyStyle': {
                    'description': 'Chart overall style',
                    'baseType': 'STYLEDEFINITION',
                    'isVisible': true,
                    'defaultValue': 'DefaultChartStyle'
                },
                'ChartTitleStyle': {
                    'description': 'Chart title style',
                    'baseType': 'STYLEDEFINITION',
                    'defaultValue': 'DefaultChartTitleStyle'
                },
                'ChartAxisStyle': {
                    'description': 'Chart grid and outline style',
                    'baseType': 'STYLEDEFINITION',
                    'isVisible': true,
                    'defaultValue': 'DefaultChartAxisStyle'
                },
                'ChartTitleAlignment': {
                    'baseType': 'STRING',
                    'defaultValue': 'center',
                    'selectOptions': [
                        { value: 'left', text: 'Left' },
                        { value: 'center', text: 'Center' },
                        { value: 'right', text: 'Right' }
                    ]
                },
                'ShowZoomStrip': {
                    'description': 'Display zoom control below graph',
                    'baseType': 'BOOLEAN',
                    'defaultValue': false,
                    'isVisible': !this.properties.ResponsiveLayout
                },
                'ShowInteractiveGuideline': {
                    'description': 'Display Data Tooltip',
                    'baseType': 'BOOLEAN',
                    'defaultValue': false,
                    'isVisible': true
                },
                'FillArea': {
                    'description': 'Fill the area defined by line with color',
                    'baseType': 'BOOLEAN',
                    'defaultValue': false
                },
                'ShowLegend': {
                    'description': 'Show or hide the legend',
                    'baseType': 'BOOLEAN',
                    'defaultValue': true
                },
                /*
                'ShowX-AxisMinMax':{
                    'description': 'Display rounded min and max values',
                    'baseType': 'BOOLEAN',
                    'defaultValue': true
                },
                */
                'AutoScale': {
                    'isVisible': true,
                    'description': 'Automatically scale the chart to fit data',
                    'baseType': 'BOOLEAN',
                    'defaultValue': true
                },
                'X-AxisIntervals': {
                    'description': 'Preferred X axis chart intervals (affects ticks, grid)',
                    'baseType': 'STRING',
                    'defaultValue': 'auto',
                    'selectOptions': [
                        { value: 'auto', text: 'Auto' },
                        { value: 'per', text: 'One Per Row' },
                    ]
                },
                'ShowX-AxisLabels': {
                    'description': 'Show X axis labels',
                    'baseType': 'BOOLEAN',
                    'defaultValue': true
                },
                'ShowY-AxisMinMax':{
                    'description': 'Display rounded min and max values',
                    'baseType': 'BOOLEAN',
                    'defaultValue': true
                },
                'Y-AxisIntervals': {
                    'description': 'Preferred Y axis chart intervals (affects ticks, grid)',
                    'baseType': 'STRING',
                    'selectOptions': [
                        { value: 'auto', text: 'Auto' },
                        { value: 'per', text: 'One Per Row' },
                    ]
                },
                'ShowY-AxisLabels': {
                    'description': 'Show Y axis labels',
                    'baseType': 'BOOLEAN',
                    'defaultValue': true
                },
                'Y-AxisMinimum': {
                    'isBindingTarget': true,
                    'isVisible': true,
                    'description': 'Minimum range for the Y axis',
                    'baseType': 'NUMBER',
                    'defaultValue': 0.0
                },
                'Y-AxisMaximum': {
                    'isBindingTarget': true,
                    'isVisible': true,
                    'description': 'Maximum range for the Y axis',
                    'baseType': 'NUMBER',
                    'defaultValue': 100.0
                },
                'Margins':{
                    'isVisible': true,
                    'description': 'Additional label margin pixel values Top, Left, Bottom, Right',
                    'baseType': 'STRING',
                    'defaultValue': '0,0,0,0'
                },
                'Width': {
                    'defaultValue': 640
                },
                'Height': {
                    'defaultValue': 240
                },
                'Z-index': {
                    'baseType': 'NUMBER',
                    'defaultValue': 10
                }
            }
        };

        var seriesNumber;
        for (seriesNumber = 1; seriesNumber <= this.MAX_SERIES; seriesNumber++) {
            var datasetProperty = {
                'description': 'Series data source ' + seriesNumber,
                'isBindingTarget': true,
                'isEditable': false,
                'baseType': 'INFOTABLE',
                'warnIfNotBoundAsTarget': false,
                'isVisible': true
            };

            var datalabelProperty = {
                'description': 'Series data label ' + seriesNumber,
                'baseType': 'STRING',
                'isBindingTarget': true,
                'isVisible': true,
                'isLocalizable': true
            };

            var datafieldProperty = {
                'description': 'Series data field ' + seriesNumber,
                'baseType': 'FIELDNAME',
                'sourcePropertyName': 'Data',
                'isBindingTarget': false,
                'baseTypeRestriction': 'NUMBER',
                'isVisible': true
            };
            var seriesStyleProperty = {
                'description': 'Series style ' + seriesNumber,
                'baseType': 'STYLEDEFINITION',
                'isVisible': true
            };

            properties.properties['DataSource' + seriesNumber] = datasetProperty;
            properties.properties['DataField' + seriesNumber] = datafieldProperty;
            properties.properties['DataLabel' + seriesNumber] = datalabelProperty;
            properties.properties['SeriesStyle' + seriesNumber] = seriesStyleProperty;
            properties.properties['SeriesStyle' + seriesNumber]['defaultValue'] = 'DefaultChartStyle' + seriesNumber;
        }

        return properties;
    };

    this.setSeriesAxisProperties = function(value) {

        var seriesNumber;
        for (seriesNumber = 1; seriesNumber <= this.MAX_SERIES; seriesNumber++) {
            var datasetProperty = {
                'description': 'Series data source ' + seriesNumber,
                'isBindingTarget': true,
                'isEditable': false,
                'baseType': 'INFOTABLE',
                'warnIfNotBoundAsTarget': false,
                'isVisible': true
            };

            var datalabelProperty = {
                'description': 'Series data label ' + seriesNumber,
                'baseType': 'STRING',
                'isBindingTarget': true,
                'isVisible': true,
                'isLocalizable': true
            };

            var datafieldProperty = {
                'description': 'Series data field ' + seriesNumber,
                'baseType': 'FIELDNAME',
                'sourcePropertyName': 'Data',
                'isBindingTarget': false,
                'baseTypeRestriction': 'NUMBER',
                'isVisible': true
            };

            var seriesStyleProperty = {
                'description': 'Series style ' + seriesNumber,
                'baseType': 'STYLEDEFINITION',
                'isVisible': true
            };
            properties.properties['DataSource' + seriesNumber] = datasetProperty;
            properties.properties['DataField' + seriesNumber] = datafieldProperty;
            properties.properties['DataLabel' + seriesNumber] = datalabelProperty;
            properties.properties['SeriesStyle' + seriesNumber] = seriesStyleProperty;
            properties.properties['SeriesStyle' + seriesNumber]['defaultValue'] = 'DefaultChartStyle' + seriesNumber;
        }

        return properties;
    };
    this.setSeriesProperties = function (value, singleSource) {
        var allWidgetProps = this.allWidgetProperties();

        var seriesNumber;

        if (singleSource) {
            for (seriesNumber = 1; seriesNumber <= value; seriesNumber++) {
                allWidgetProps['properties']['DataField' + seriesNumber]['sourcePropertyName'] = 'Data';
                allWidgetProps['properties']['DataField' + seriesNumber]['isVisible'] = true;
                allWidgetProps['properties']['SeriesStyle' + seriesNumber]['isVisible'] = true;
                allWidgetProps['properties']['DataLabel' + seriesNumber]['isVisible'] = true;
                allWidgetProps['properties']['DataSource' + seriesNumber]['isVisible'] = false;
            }
            for (seriesNumber = value + 1; seriesNumber <= this.MAX_SERIES; seriesNumber++) {
                allWidgetProps['properties']['DataField' + seriesNumber]['isVisible'] = false;
                allWidgetProps['properties']['SeriesStyle' + seriesNumber]['isVisible'] = false;
                allWidgetProps['properties']['DataLabel' + seriesNumber]['isVisible'] = false;
                allWidgetProps['properties']['DataSource' + seriesNumber]['isVisible'] = false;
            }
            allWidgetProps['properties']['Data']['isVisible'] = true;
        }else{
            for (seriesNumber = 1; seriesNumber <= value; seriesNumber++) {
                allWidgetProps['properties']['DataField' + seriesNumber]['sourcePropertyName'] = 'DataSource' + seriesNumber;
                allWidgetProps['properties']['DataField' + seriesNumber]['isVisible'] = true;
                allWidgetProps['properties']['SeriesStyle' + seriesNumber]['isVisible'] = true;
                allWidgetProps['properties']['DataLabel' + seriesNumber]['isVisible'] = true;
                allWidgetProps['properties']['DataSource' + seriesNumber]['isVisible'] = true;
            }
            for (seriesNumber = value + 1; seriesNumber <= this.MAX_SERIES; seriesNumber++) {
                allWidgetProps['properties']['DataField' + seriesNumber]['isVisible'] = false;
                allWidgetProps['properties']['SeriesStyle' + seriesNumber]['isVisible'] = false;
                allWidgetProps['properties']['DataLabel' + seriesNumber]['isVisible'] = false;
                allWidgetProps['properties']['DataSource' + seriesNumber]['isVisible'] = false;
            }
            allWidgetProps['properties']['Data']['isVisible'] = false;
        }
    };

    this.widgetEvents = function () {
        return {
        	'DoubleClicked': {}
        };
    };


    this.renderHtml = function () {
        var html = '';
        html += '<div class="widget-content widget-lineChart">'
             +  '<table height="100%" width="100%"><tr><td valign="middle" align="center">'
             +  '<span>Line Chart</span>'
             +  '</td></tr></table></div>';
        return html;
    };

    this.afterRender = function () {
        // this property can't be hidden in setProperties because ResponsiveLayout is still undefined in most cases
        this.allWidgetProperties()['properties']['ShowZoomStrip']['isVisible'] = !this.properties.ResponsiveLayout;
        this.updatedProperties();
    };

    this.afterLoad = function () {
        this.setSeriesProperties(this.getProperty('NumberOfSeries'), this.getProperty('SingleDataSource'));
        //this.setSeriesAxisProperties(this.getProperty('NumberOfSeries'));
    };

    this.afterSetProperty = function (name, value) {
        if (name === 'Width' ||
            name === 'Height' ||
            name==='ChartTitle' ||
            name==='Alignment') {
            return true;
        }

        if (name === 'ShowAxisLabels'){
            allWidgetProps['properties']['X-AxisLabel']['isVisible'] = this.getProperty('ShowAxisLabels');
            allWidgetProps['properties']['Y-AxisLabel']['isVisible'] = this.getProperty('ShowAxisLabels');
            this.updatedProperties();
            return true;
        }

        if (name === 'NumberOfSeries' || name === 'SingleDataSource') {

            this.setSeriesProperties(this.getProperty('NumberOfSeries'), this.getProperty('SingleDataSource'));
            this.updatedProperties();

            return true;
        }

        if (name.indexOf('Y-AxisMode') === 0) {
            this.setSeriesAxisProperties(this.getProperty('NumberOfSeries'));
            this.updatedProperties();

            return true;
        }
    };
    
    this.beforeSetProperty = function (name, value) {
        // first function called on a drop into mashup
        this.setSeriesProperties(this.getProperty('NumberOfSeries'), this.getProperty('SingleDataSource'));
        if (name === 'NumberOfSeries') {
            value = parseInt(value, 10);
            if (value <= 0 || value > 8)
                return "Number Of Series Must Be Between 1 and 8";
        }
    };

    this.validate = function () {
        var result = [];

        if (!this.isPropertyBoundAsTarget('Data')) {
        	var bound = false;
        	
            for (var seriesNumber = 1; seriesNumber <= this.MAX_SERIES; seriesNumber++) {
                var dsProperty = 'DataSource' + seriesNumber;
                if(this.isPropertyBoundAsTarget(dsProperty)) {
                	bound = true;
                	break;
                }
            }
            
            if(!bound)
            	result.push({ severity: 'warning', message: 'You must assign at least one data source' });
        }
        return result;
    };

    this.afterAddBindingSource = function (bindingInfo) {
        if (bindingInfo.targetProperty == "Data") {
            this.setProperty('SingleDataSource', true);

            this.setSeriesProperties(this.getProperty('NumberOfSeries'), this.getProperty('SingleDataSource'));
            this.updatedProperties();
        }
    };};