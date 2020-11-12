/*global Encoder,TW */

var TW_chart3dIsExtension;

(function () {

    var addedDefaultChartStyles = false;

    TW.Runtime.Widgets.chart3d = function () {
        var thisWidget = this,
            liveData,
            widgetProperties,
            widgetContainer,
            widgetContainerId,
            widgetSelector,
            chartContainer,
            chartContainerId,
            chart,
            purge,
            chartData,
            chartSeries = [],
            MAX_SERIES = 8,
            chartStyles = {},
            returnData = [],
            dataLabels = [],
            chartCreated = false,
            dataRows,
            valueUnderMouse = {},
            clickedRowId,
            selectedRowIndices,
            chartTitleStyle,
            isResponsive = false,
            isInHiddenTab = false,
            isInHiddenBrowserTab,
            resizeHandler;

        thisWidget.chartTitleTextSizeClass = 'textsize-normal';
        thisWidget.processing = false;
        thisWidget.singleDataSource = thisWidget.getProperty('SingleDataSource');
        thisWidget.nSeries = Math.min(MAX_SERIES, thisWidget.getProperty('NumberOfSeries'));
        thisWidget.title = thisWidget.getProperty('ChartTitle');
        thisWidget.titleAlignment = thisWidget.getProperty("ChartTitleAlignment");
        thisWidget.xAxisLabel = thisWidget.getProperty('X-AxisLabel');
        thisWidget.yAxisLabel = thisWidget.getProperty('Y-AxisLabel');
        thisWidget.showAxisLabels = thisWidget.getProperty('ShowAxisLabels');
        thisWidget.showXAxisLabels = Boolean(thisWidget.getProperty('ShowX-AxisLabels'));
        thisWidget.showYAxisLabels = Boolean(thisWidget.getProperty('ShowY-AxisLabels'));
        thisWidget.showZoomStrip = thisWidget.getProperty('ShowZoomStrip');
        thisWidget.showInteractiveGuideline = thisWidget.getProperty('ShowInteractiveGuideline');
        thisWidget.showLegend = thisWidget.getProperty('ShowLegend');
        thisWidget.interpolation = thisWidget.getProperty('Interpolation');
        thisWidget.duration = thisWidget.getProperty('Duration');
        thisWidget.fillArea = Boolean(thisWidget.getProperty('FillArea'));
        thisWidget.labelAngle = thisWidget.getProperty('LabelAngle') * -1;
        thisWidget.xAxisIntervals = thisWidget.getProperty('X-AxisIntervals');
        thisWidget.xAxisMinMaxVisible = Boolean(thisWidget.getProperty('ShowX-AxisMinMax'));
        thisWidget.yAxisMinimum = thisWidget.getProperty('Y-AxisMinimum')*1;
        thisWidget.yAxisMaximum = thisWidget.getProperty('Y-AxisMaximum')*1;
        thisWidget.autoScale = Boolean(thisWidget.getProperty('AutoScale'));
        thisWidget.yAxisIntervals = thisWidget.getProperty('Y-AxisIntervals');
        thisWidget.yAxisMinMaxVisible = thisWidget.getProperty('ShowY-AxisMinMax');
        thisWidget.margins = thisWidget.getProperty('Margins');
        thisWidget.width = thisWidget.getProperty('Width');
        thisWidget.height = thisWidget.getProperty('Height');
        thisWidget.zIndex = thisWidget.getProperty('Z-index');
        thisWidget.selectedItems = [];
        thisWidget.enableSelection = true;
        thisWidget.emptyChart = false;
        thisWidget.xAxisField = thisWidget.getProperty('X-AxisField');

        (function () {
            var hidden = "hidden";
            // Standards:
            if (hidden in document) {
                document.addEventListener("visibilitychange", onchange);
            } else if ((hidden = "mozHidden") in document) {
                document.addEventListener("mozvisibilitychange", onchange);
            } else if ((hidden = "webkitHidden") in document) {
                document.addEventListener("webkitvisibilitychange", onchange);
            } else if ((hidden = "msHidden") in document) {
                document.addEventListener("msvisibilitychange", onchange);
            }

            function onchange(evt) {
                var v = "visible", h = "hidden",
                    evtMap = { focus: v,focusin: v,pageshow: v,blur: h,focusout: h,pagehide: h};
                evt = evt || window.event;
                if (evt.type in evtMap) {
                    document.body.className = evtMap[evt.type];
                    isInHiddenBrowserTab = evtMap[evt.type].charAt(0)==="h";
                } else {
                    document.body.className = this[hidden] ? "hidden" : "visible";
                    isInHiddenBrowserTab = this[hidden];
                }
            }

            // set the initial state (but only if browser supports the Page Visibility API)
            if (document[hidden] !== undefined) {
                onchange({type: document[hidden] ? "blur" : "focus"});
            }
        })();

        this.runtimeProperties = function () {
            return {
                'needsDataLoadingAndError': false
            };
        };

        this.renderHtml = function () {
            return renderChartHtml(thisWidget, "chart3d");
        };

        this.renderStyles = function () {

            var formatResult = TW.getStyleFromStyleDefinition(thisWidget.getProperty('ChartBodyStyle', 'DefaultChartStyle'));
            chartTitleStyle = TW.getStyleFromStyleDefinition(thisWidget.getProperty('ChartTitleStyle', 'DefaultChartTitleStyle'));
            var chartAxisStyle = TW.getStyleFromStyleDefinition(thisWidget.getProperty('ChartAxisStyle', 'DefaultChartAxisStyle'));
            var chartTitleStyleBG = TW.getStyleCssGradientFromStyle(chartTitleStyle);
            var chartTitleStyleText = TW.getStyleCssTextualNoBackgroundFromStyle(chartTitleStyle);
            var chartBackground = TW.getStyleCssGradientFromStyle(formatResult);
            var chartBorder = TW.getStyleCssBorderFromStyle(formatResult);
            // chart series lines are stroked in color in svg processing, not in css
            // to be replaced with iterator on however many series/styles were set up
            var chartStyle1 = TW.getStyleFromStyleDefinition(thisWidget.getProperty('SeriesStyle1','DefaultChartStyle1'));
            var chartStyle2 = TW.getStyleFromStyleDefinition(thisWidget.getProperty('SeriesStyle2','DefaultChartStyle2'));
            var chartStyle3 = TW.getStyleFromStyleDefinition(thisWidget.getProperty('SeriesStyle3','DefaultChartStyle3'));
            var chartStyle4 = TW.getStyleFromStyleDefinition(thisWidget.getProperty('SeriesStyle4','DefaultChartStyle4'));
            var chartStyle5 = TW.getStyleFromStyleDefinition(thisWidget.getProperty('SeriesStyle5','DefaultChartStyle5'));
            var chartStyle6 = TW.getStyleFromStyleDefinition(thisWidget.getProperty('SeriesStyle6','DefaultChartStyle6'));
            var chartStyle7 = TW.getStyleFromStyleDefinition(thisWidget.getProperty('SeriesStyle7','DefaultChartStyle7'));
            var chartStyle8 = TW.getStyleFromStyleDefinition(thisWidget.getProperty('SeriesStyle8','DefaultChartStyle8'));
            chartStyles.series1 = chartStyle1.foregroundColor;
            chartStyles.series2 = chartStyle2.foregroundColor;
            chartStyles.series3 = chartStyle3.foregroundColor;
            chartStyles.series4 = chartStyle4.foregroundColor;
            chartStyles.series5 = chartStyle5.foregroundColor;
            chartStyles.series6 = chartStyle6.foregroundColor;
            chartStyles.series7 = chartStyle7.foregroundColor;
            chartStyles.series8 = chartStyle8.foregroundColor;
            var styleBlock = '';

            var chartCssInfo = TW.getStyleCssTextualNoBackgroundFromStyle(formatResult);
            var chartLineInfo = TW.getStyleCssBorderFromStyle(chartAxisStyle);

            // d3 uses color values directly
            chartStyles.text = chartCssInfo.split(';')[0].split(':')[1];
            chartStyles.gridStyle = chartLineInfo.split(';')[1].split(':')[1];
            //regular widget styles
            if (thisWidget.getProperty('ChartBodyStyle', 'DefaultChartStyle') === 'DefaultChartStyle'
                && thisWidget.getProperty('ChartTitleStyle', 'DefaultChartTitleStyle') === 'DefaultChartTitleStyle'
                && thisWidget.getProperty('FocusStyle', 'DefaultButtonFocusStyle') === 'DefaultButtonFocusStyle') {
                if (!addedDefaultChartStyles) {
                    addedDefaultChartStyles = true;
                    // add chart title default style
                    var defaultStyles = '.chart-title {' + chartTitleStyleBG + ' ' + chartTitleStyleText + ' }' +
                        ' .widget-chart3d {' + chartBackground +' '+ chartBorder +' }';
                    $.rule(defaultStyles).appendTo(TW.Runtime.globalWidgetStyleEl);
                }
            } else {
                // add custom chart title style
                styleBlock += '#' + thisWidget.jqElementId + ' .chart-title { ' + chartTitleStyleBG + ' ' + chartTitleStyleText + ' } ' +
                    '#' + thisWidget.jqElementId + '.widget-chart-title-text { ' + chartTitleStyle + ' }' +
                    '#' + thisWidget.jqElementId + '.widget-chart3d {' + chartBackground + chartBorder + '}';
            }
            return styleBlock;

        };

        this.afterRender = function () {
            widgetProperties = thisWidget.properties;
            widgetContainer = thisWidget.jqElementId;
            widgetContainerId = '#' + widgetContainer;
            chartContainer = widgetContainer + '-chart'; //root_nvd3line-6-chart
            chartContainerId = '#' + chartContainer; //#root_nvd3line-6-chart

            // look to see if chart is in a mashupContainer
            // class contains widget-mashupcontainer
            widgetSelector = widgetContainer + ' .-element';
            // add svg tag to html element required to inject chart
            $('<svg id="' + chartContainer + '" ></svg>').appendTo(widgetContainerId);

            // styles
            var chartTitleElement = $(widgetContainerId).find('.chart-title');
            chartTitleElement.switchClass('textsize-normal', thisWidget.chartTitleTextSizeClass);

            // events
            $(widgetSelector).on('focus', function () {
                $(widgetContainer).addClass('focus');
            });

            $(widgetSelector).on('blur', function (e) {
                $(widgetContainer).removeClass('focus');
            });

            thisWidget.jqElement.dblclick(thisWidget.dblClickHandler);

            thisWidget.jqElement.find('.nv-legend').on('click', function (e) {
                thisWidget.jqElement.triggerHandler('DoubleClicked');
                e.preventDefault();
            });

            if (thisWidget.properties.ResponsiveLayout) {
                isResponsive = true;
                $(widgetContainerId + '-bounding-box').height('100%').width('100%');
                $(widgetContainerId + '-bounding-box').css('overflow','hidden');
                $(widgetContainerId).height("100%").width("100%");
                $(chartContainerId).height("100%").width("100%");
                $(widgetContainerId).css('overflow','hidden');
            } else {
                $(chartContainerId).width(thisWidget.width + 20);
                $(chartContainerId).height(thisWidget.height - 24);
            }

            $(widgetContainerId + '-bounding-box').css('z-index',thisWidget.zIndex);
            
            // get unbound dataLabel strings
            for (var i = 1; i < thisWidget.nSeries + 1; i++) {
                var dataLabel = widgetProperties['DataLabel' + i];
                if (dataLabel !== undefined && dataLabel !== '') {
                    dataLabels.push(dataLabel);
                } else {
                    dataLabels.push("Series " + i);
                }
            }

            dataLabels = this.forceUniqueValues(dataLabels);

            $(window).on('resize', _.debounce(thisWidget.processDataset, 300));
        };

        this.updateProperty = function (updatePropertyInfo) {
            var thisWidget = this;
            var widgetProperties = thisWidget.properties;
            var seriesNumber;
            var nSeries = thisWidget.nSeries;

            // if this is in a inactive tab or similar we must prevent rendering until tab gets clicked
            if(isResponsive && $(widgetContainerId).closest('.tabsv2-actual-tab-contents').css('display')==='none') {
                isInHiddenTab = true;
                $(chartContainerId).hide();
            }else{
                isInHiddenTab = false;
                $(chartContainerId).fadeIn(thisWidget.duration);
            }

            if (updatePropertyInfo.TargetProperty === "ChartTitle") {
                var updatedTitle = updatePropertyInfo.RawSinglePropertyValue;
                thisWidget.setProperty('ChartTitle', updatedTitle);
                thisWidget.title = updatedTitle;
                $('#' + thisWidget.jqElementId + '-title').text(updatedTitle);
                return;
            }

            if (updatePropertyInfo.TargetProperty === "Y-AxisMinimum") {
                thisWidget.yAxisMinimum = updatePropertyInfo.RawSinglePropertyValue;
                if(chart !== undefined && thisWidget.autoScale === false && thisWidget.yAxisMinimum < thisWidget.yAxisMaximum) {
                    chart.forceY([thisWidget.yAxisMinimum, thisWidget.yAxisMaximum]);
                }
                return;
            }

            if (updatePropertyInfo.TargetProperty === "Y-AxisMaximum") {
                thisWidget.yAxisMaximum = updatePropertyInfo.RawSinglePropertyValue;
                if(chart !== undefined && thisWidget.autoScale === false && thisWidget.yAxisMinimum < thisWidget.yAxisMaximum) {
                    chart.forceY([thisWidget.yAxisMinimum, thisWidget.yAxisMaximum]);
                }
                return;
            }

            if (updatePropertyInfo.TargetProperty.indexOf('Data') === 0 && !isInHiddenBrowserTab && thisWidget.processing === false) {
                dataRows = updatePropertyInfo.ActualDataRows;
                // iterate through the series fields
                if (updatePropertyInfo.TargetProperty === "Data") {
                    chartSeries = [];
                    for (seriesNumber = 1; seriesNumber <= nSeries; seriesNumber++) {

                        var dataField = widgetProperties['DataField' + seriesNumber];

                        if (dataField !== undefined && dataField !== '' && dataRows != undefined) {

                            var seriesType = widgetProperties['SeriesType' + seriesNumber];

                            if (seriesType == 'chart' || seriesType === undefined || seriesType == null) {
                                seriesType = widgetProperties['ChartType'];
                            }

                            this.enableSelection = widgetProperties['AllowSelection'];

                            var seriesmarkerType = widgetProperties['SeriesMarkerType' + seriesNumber];
                            if (seriesmarkerType === undefined || seriesmarkerType == 'chart')
                                seriesmarkerType = widgetProperties['MarkerType'];

                            var seriesDefinition = {
                                dataSource: updatePropertyInfo.TargetProperty,
                                type: seriesType,
                                field: dataField,
                                data: dataRows,
                                label: this.getProperty('DataLabel' + seriesNumber),
                                style: widgetProperties['SeriesStyle' + seriesNumber],
                                markertype: seriesmarkerType
                            };

                            chartSeries.push(seriesDefinition);
                        }else{
                            TW.log.warn("dataField is empty or undefined");
                        }
                    }
                    this.processDataset();
                }else if (updatePropertyInfo.TargetProperty.indexOf('DataLabel') === 0) {
                    for (seriesNumber = 1; seriesNumber <= nSeries; seriesNumber++) {
                        var labelName = 'DataLabel' + seriesNumber.toString();
                        if (updatePropertyInfo.TargetProperty === labelName && updatePropertyInfo.RawSinglePropertyValue !== undefined) {
                            thisWidget.setProperty(labelName, updatePropertyInfo.RawSinglePropertyValue);
                            dataLabels = this.forceUniqueValues(dataLabels);
                            // replace the dataLabel by position in array dataLabels
                            dataLabels[seriesNumber - 1] = thisWidget.getProperty(labelName);
                            // set the label of the corresponding chartSeries element in liveData
                            liveData[seriesNumber - 1].key = dataLabels[seriesNumber - 1];
                            if(! isInHiddenTab) {
                                liveData = this.processDataset();
                            }
                        }
                    }
                } else {
                    // multiple datasource handling
                    if (dataRows !== undefined && !thisWidget.singleDataSource) {
                        // each data load resets the purge timeout
                        // so we only purge after final data load in case some dataSources were deselected
                        clearTimeout(purge);
                        purge = setTimeout(function(){purgeDataSources(dataSourceId)}, 300);
                        var dataSourceName = updatePropertyInfo.TargetProperty;

                        //check if targetProperty is a dataSource already displayed
                        var newSeries = true;

                        var dataSourceId = dataSourceName.substr(dataSourceName.length - 1, 1);
                        for (var i = 0; i < chartSeries.length; i++) {
                            // if the series' datasource is already in chartSeries
                            // or the id is greater than the max number of series allowed it is a repeat
                            if (chartSeries[i].dataSource === updatePropertyInfo.TargetProperty || dataSourceId > nSeries) {
                                newSeries = false;
                            }
                        }

                        var dataField = widgetProperties['DataField' + dataSourceId];

                        var seriesDefinition = {
                            dataSource: dataSourceName,
                            id: dataSourceId,
                            field: dataField,
                            data: dataRows,
                            label: this.getProperty('DataLabel' + dataSourceId),
                            style: widgetProperties['SeriesStyle' + dataSourceId]
                        };

                        // if existing dataSource, update
                        if (newSeries === false) {
                            chartSeries.splice(dataSourceId - 1, 1, seriesDefinition);
                            // replace the dataLabel by position in array dataLabels
                            dataLabels.splice(dataSourceId - 1, 1, seriesDefinition.label);
                            // set the label of the corresponding chartSeries element in liveData
                            if(liveData !== undefined) {
                                liveData[dataSourceId].key = dataLabels[dataSourceId];
                            }
                        }

                        // if new dataSource, add
                        if (newSeries === true) {
                            // if max series already displayed, drop FIFO
                            if (chartSeries.length > nSeries) {
                                chartSeries.shift();
                                dataLabels.shift();
                            }
                            chartSeries.push(seriesDefinition);
                        }

                    }else{
                        TW.log.warn("data rows undefined or empty for targetProperty: " + updatePropertyInfo.TargetProperty);
                    }
                    this.processDataset();
                }
            }

            if(thisWidget.enableSelection) {

                var selectedRowIndices = updatePropertyInfo.SelectedRowIndices;

                if (selectedRowIndices !== undefined) {
                    //this is chart updating selection flags to match grid row
                    //TW.ChartLibrary.handleChartSelectionUpdate(this, this.chart, updatePropertyInfo.TargetProperty, selectedRowIndices);
                }
                else {
                    TW.ChartLibrary.handleChartSelectionUpdate(this, this.chart, updatePropertyInfo.TargetProperty, new Array());
                }
            }
        };

        function purgeDataSources(dataSourceId){
            if(chartSeries.length>thisWidget.nSeries) {
                chartSeries.splice(dataSourceId, (chartSeries.length - thisWidget.nSeries));
                if(! isInHiddenTab) {
                    liveData = thisWidget.processDataset();
                }
            }
        }

        this.processDataset = function () {
            thisWidget.processing = true;
            var nRows = 0,
            // the field selected to supply data in the series
            seriesFieldName,
            // the field providing labels along the x-axis
            xAxisField,
            nSeries = thisWidget.nSeries,
            singleDataSource = thisWidget.singleDataSource;
            returnData = [];

            var nSeriesToProcess = singleDataSource ? nSeries : chartSeries.length;
            for (var i = 0; i < nSeriesToProcess; i++) {
                var dataSource = chartSeries[i];
                var data;

                xAxisField = singleDataSource ? thisWidget.xAxisField : thisWidget['xAxisField' + chartSeries[i].id];

                if(dataSource !== undefined) {
                    seriesFieldName = dataSource.field;
                    data = dataSource.data;

                } else {
                    var message = "Error: A " + (singleDataSource ? "DataField" : "DataSource") + " needs to be selected";
                    //this might need to go in a try/catch
                    showEmptyChart(thisWidget, chart);
                    TW.log.error(message);
                    return;
                }

                if (seriesFieldName !== undefined && seriesFieldName != "") {
                    var seriesValue,
                    seriesValues = [],
                    obj,
                    offset;

                    nRows = data.length;

                    // if 0 rows return from service but chart already drawn from previous rows, we need to clear chart
                    if (nRows === 0) {
                        seriesData = {
                            'values': [],
                            'key': TW.Runtime.convertLocalizableString(dataLabels[0]),
                            'color': chartStyles['series' + (i + 1)]
                        };
                        returnData.push(seriesData);

                    } else {
                        thisWidget.jqElement.find(".nv-area").show();
                        thisWidget.jqElement.find(".nv-linesWrap").show();
                        thisWidget.jqElement.find(".nv-wrap text").show();
                        if(thisWidget.showInteractiveGuideline === true) {
                            $('.xy-tooltip').show();
                        }

                        for (var rowid = 0; rowid < nRows; rowid++) {
                            if (offset === undefined) {
                                offset = Math.max(1, rowid);
                            }
                            var row = data[rowid];

                            if (row[seriesFieldName] !== undefined && row[seriesFieldName] !== '') {
                                seriesValue = row[seriesFieldName];
                            } else {
                                TW.log.warn("undefined or empty seriesValue forced to 0");
                                seriesValue = 0;
                            }
                            obj = {"x": rowid + offset, "y": seriesValue};
                            //// console.log("obj.x: "+obj.x+" obj.y: "+obj.y);
                            //console.log("pds obj.y: " + obj.y);
                            seriesValues.push(obj);
                        }
                        var seriesData = {
                            'values': seriesValues,
                            // key should be label prop w fallback to dataSourceName
                            'key': TW.Runtime.convertLocalizableString(dataLabels[i]),
                            'color': chartStyles['series' + (i + 1)],
                            'area': thisWidget.fillArea
                        };
                        returnData.push(seriesData);
                    }
                }
            }

            if (returnData.length > 0 && !isInHiddenTab ) {
                if(chartData){
                    $(chartContainerId).show();
                    thisWidget.update(returnData);
                }else {
                    thisWidget.render(returnData);
                }
                thisWidget.processing = false;
                return returnData;
            }
        };

        this.resize = function(width, height) {
            isInHiddenTab = chartResize(thisWidget, widgetContainerId, isInHiddenTab);
        };

        this.render = function (data, isUpdate) {
            $('.xy-tooltip').remove();
            var propMargin = thisWidget.margins.split(',');
            var xLabelMargin = (isResponsive ? 63 : 42) + propMargin[2]*1;
            var yLabelMargin = 56 + propMargin[1]*1;
            var legendMargin = 28 + propMargin[0]*1;
            var showLegend = thisWidget.showLegend === true && thisWidget.nSeries > 1;

            // this will create an empty chart
            if (data === undefined) {
                showEmptyChart(thisWidget, chart);
                TW.log.error('timeSeriesChartV2 widget extension, data undefined');
            }

            if (isUpdate !== undefined && isUpdate === true) {
                chartData.datum(data).transition().duration(thisWidget.duration).call(chart);
                if(!resizeHandler){
                    resizeHandler = nv.utils.windowResize(chart.update);
                }
            } else {
                nv.addGraph(function () {
                    chart = nv.models.chart3d();
                    chart.focusEnable( thisWidget.showZoomStrip );
                    chart.x2Axis.tickFormat(function (d) {})
                         .showMaxMin(!!thisWidget.xAxisMinMaxVisible)
                         .ticks();
                    chart.y2Axis
                         .showMaxMin(false);
                    chart.showYAxis(thisWidget.showYAxisLabels)
                         .showXAxis(thisWidget.showXAxisLabels);
                    chart.duration(thisWidget.duration);
                    if(thisWidget.showAxisLabels) {
                        chart.xAxis.axisLabel(thisWidget.xAxisLabel);
                        chart.yAxis.axisLabel(thisWidget.yAxisLabel);
                        yLabelMargin += isResponsive ? 14 : 7;
                        xLabelMargin += isResponsive ? 42 : 21;
                    }

                    if(!thisWidget.showAxisLabels && thisWidget.xAxisIntervals + thisWidget.yAxisIntervals > 0) {
                        yLabelMargin += 7;
                    }

                    // add margin if labelAngle used
                    if (thisWidget.labelAngle !== 0) {
                        xLabelMargin += 28;
                        yLabelMargin += 14;
                    }
                    // add margin if legend displayed
                    if (showLegend) {
                        legendMargin += 7;
                    }

                    chart.margin({top: legendMargin+(propMargin[0]*1), left: yLabelMargin, bottom: xLabelMargin, right: 40+(propMargin[3]*1)})  //Adjust chart margins to give the x-axis some breathing room.
                        .useInteractiveGuideline(thisWidget.showInteractiveGuideline)
                        .duration(thisWidget.duration)  //how fast do you want the lines to transition?
                        .showLegend(showLegend)      //Show the legend, allowing users to turn on/off line series.
                        .height = (isResponsive ? $(widgetContainerId + '-bounding-box').height() : thisWidget.height - xLabelMargin);

                    // set the y scale to user settings
                    if(thisWidget.autoScale===false && thisWidget.yAxisMinimum!=='') {

                        if(thisWidget.yAxisMaximum>thisWidget.yAxisMinimum){
                            chart.forceY([thisWidget.yAxisMinimum,thisWidget.yAxisMaximum]);
                        }else {
                            chart.forceY(thisWidget.yAxisMinimum);
                        }
                    }

                    chart.interpolate(thisWidget.interpolation);
                    // override default tooltip in interactive layer
                    if(thisWidget.showInteractiveGuideline) {
                        chart.interactiveLayer.tooltip.contentGenerator(function (d) {
                            return thisWidget.tooltipGenerator(d);
                        });
                    }else{
                        chart.lines.interactive(false);
                    }

                    chart.options = nv.utils.optionsFunc.bind(chart);
                    chart.xAxis
                        .showMaxMin(!!thisWidget.xAxisMinMaxVisible)
                        .rotateLabels(thisWidget.labelAngle)
                        .tickPadding(10)
                        .tickFormat(d3.format('.02f'));
                    if(thisWidget.xAxisIntervals!=="auto"){
                        chart.xAxis.ticks( data[0].values.length);
                    }

                    //.tickValues(liveData[0]);
                    // .ticks(thisWidget.xAxisIntervals);
                    chart.yAxis
                        .showMaxMin(!!thisWidget.yAxisMinMaxVisible)
                        .tickFormat(d3.format('.02f'));//money
                        //.tickFormat(d3.format('.0d'));
                    thisWidget.yAxisIntervals==="per" ? chart.yAxis.ticks(data[0].values.length): chart.yAxis.ticks();

                    // data applied to chart in div to create it first time
                    chartData = d3.select(chartContainerId).datum(data);
                    chartData.transition().duration(thisWidget.duration).call(chart);
                    $('.xy-tooltip').remove();

                    doUpdateStyles();

                    if(!resizeHandler){
                        resizeHandler = nv.utils.windowResize(function () {
                            chart.update();
                        });
                    }

                    chart.dispatch.on('stateChange', function (e) {
                        chart.useInteractiveGuideline(false);
                        updateStyles(e)
                    });
                });
            }

            // triggered by chart clicks
            function handleClick() {
                //scrape highlighted entry on guide, look it up in series
                var fieldName = chartSeries[valueUnderMouse.series].field;
                var seriesData = chartSeries[valueUnderMouse.series].data;

                for (var i = 0; i < seriesData.length; i++) {
                    if (seriesData[i][fieldName] === valueUnderMouse.value) {
                        // this is the row in datasource series
                        clickedRowId = i;
                        thisWidget.setSeriesSelection();
                    }
                }
            }

            // triggered by legend click
            function updateStyles(e) {
                $('.xy-tooltip').remove();
                setTimeout(function () {
                    doUpdateStyles();
                }, thisWidget.duration);
            }

            function doUpdateStyles() {
                d3.selectAll(widgetContainerId + '-chart .nv-line')
                    .style("fill", "none");
                d3.selectAll(widgetContainerId+'-chart text')
                    .style("fill", chartStyles.text);
                d3.selectAll(widgetContainerId+'-chart nv-legend-text')
                    .style("fill", chartStyles.text);
                d3.selectAll(widgetContainerId+'-chart line')
                    .style("stroke", chartStyles.gridStyle);
                d3.selectAll(widgetContainerId+'-chart path')
                    .style("cursor","pointer")
                    .style("pointer-events", "all")
                    .on('click',function(e){
                        handleClick();
                    });

                $('.xy-tooltip').remove();
                chart.useInteractiveGuideline(thisWidget.showInteractiveGuideline);
            }
        };

        var chart_x;
        var chart_width;
        var chart_y;
        var chart_height;
        var targetShape;
        var targetShapePos;

        this.update = function (data){
            // Update the SVG with the new data and call chart

            /* when there are no rows we need to figure out if the chart should do one of the following:
            ** 1 if single series, show an empty chart gracefully (more on what that means... )
            *  2 if multi series and this is the first one empty, keep paying attention in case they are all empty
            *  3 if at least one series has data, skip over the empty ones but keep track of wheich ones have data
            */

            thisWidget.emptyChart = true;

            for (var i = 0; i < data.length; i++) {
                if (data[i].values.length > 0) {
                    thisWidget.emptyChart = false;
                    break;
                }
            }

            if(thisWidget.emptyChart === true) {
                // we have an empty single series chart
                showEmptyChart(thisWidget, chart);
            } else {
                chartData.datum(data).transition().duration(500).call(chart);
                chart.useInteractiveGuideline(thisWidget.showInteractiveGuideline);
                if (!resizeHandler) {
                    resizeHandler = nv.utils.windowResize(chart.update);
                }
            }
        };

        this.dblClickHandler = function(){
            thisWidget.jqElement.triggerHandler('DoubleClicked');
        };

        // this probably has to be run multiple times due to dataLabel being a dynamic runtime property
        // check for duplicate datalabels and append numeric suffix if needed
        this.forceUniqueValues = function (dataLabels) {
            var data = dataLabels;
            return data.map(function (item) {
                return this[item].count === 1 ? item : item + '-' + ++this[item].index;
            }, data.reduce(function (retVal, item) {
                retVal[item] = retVal[item] || {count: 0, index: 0};
                retVal[item].count++;
                return retVal;
            }, {}));
        };

        //Format function for the tooltip values column
        this.valueFormatter = function(d,i) {
            return d;
        };

        //Format function for the tooltip header value.
        this.headerFormatter = function(d) {
            return d;
        };

        this.keyFormatter = function(d, i) {
            return d;
        };

        this.tooltipGenerator = function(d) {
            var headerEnabled = true;
            if (d === null) {
                return '';
            }

            var table = d3.select(document.createElement("table"));
            if (headerEnabled) {
                var theadEnter = table.selectAll("thead")
                    .data([d])
                    .enter().append("thead");

                theadEnter.append("tr")
                    .append("td")
                    .attr("colspan", 3)
                    .append("strong")
                    .classed("x-value", true)
                    //.html(headerFormatter(d.value)); // default is to use x value, which has no meaning
                    // use x-axis label, assume it id's "something" in quantity of something
                    .html(thisWidget.headerFormatter(d.value));
            }

            var tbodyEnter = table.selectAll("tbody")
                .data([d])
                .enter().append("tbody");
            var rowEnterCounter = 0;
            var trowEnter = tbodyEnter.selectAll("tr")
                .data(function(p) { return p.series})
                .enter()
                .append("tr")
                .classed("highlight", function(p, i) {

                    if(p.highlight){
                        valueUnderMouse.series = rowEnterCounter;
                        valueUnderMouse.value = p.value;
                        rowEnterCounter = 0;
                    }else{
                        rowEnterCounter++;
                    }

                    return p.highlight
                });

            trowEnter.append("td")
                .classed("legend-color-guide",true)
                .append("div")
                .style("background-color", function(p) { return p.color});

            trowEnter.append("td")
                .classed("key",true)
                .html(function(p, i) {return thisWidget.keyFormatter(p.key, i)});

            trowEnter.append("td")
                .classed("value",true)
                .html(function(p, i) { return thisWidget.valueFormatter(p.value, i) });

            trowEnter.selectAll("td").each(function(p) {
                if (p.highlight) {
                    var opacityScale = d3.scale.linear().domain([0,1]).range(["#fff",p.color]);
                    var opacity = 0.6;
                    d3.select(this)
                        .style("border-bottom-color", opacityScale(opacity))
                        .style("border-top-color", opacityScale(opacity));
                }
            });

            var html = table.node().outerHTML;
            if (d.footer !== undefined)
                html += "<div class='footer'>" + d.footer + "</div>";
            return html;

        };

        //single item selection publish
        this.setSeriesSelection = function () {
            selectedRowIndices = [];
            selectedRowIndices.push(clickedRowId);
            thisWidget.updateSelection('Data', selectedRowIndices);
        };

        this.beforeDestroy = function () {
            if(resizeHandler){
                resizeHandler.clear();
                resizeHandler = null;
            }
            try {
                thisWidget.jqElement.off();
            } catch (err) {
                TW.log.error('Error in TW.Runtime.Widgets.button.beforeDestroy', err);
            }
        };

    };
}());
