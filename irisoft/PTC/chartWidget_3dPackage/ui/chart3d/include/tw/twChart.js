/** common javascripts for chart widget extensions **/

/** showEmptyChart for line and time series
 *
 * @param chartWidget the chart widget that calls showEmptyChart
 * @param chart the chart object defined within the chartWidget
 */

showEmptyChart = function (chartWidget, chart) {
    chartWidget.jqElement.find(".nv-area").hide(200);
    chartWidget.jqElement.find(".nv-linesWrap").hide(200);
    chartWidget.jqElement.find(".nv-bar").hide(200);
    chartWidget.jqElement.find(".nv-wrap text").hide(200);
    if(chartWidget.showInteractiveGuideline===true) {
        $('.xy-tooltip').hide(200);
    }
    if(chart.useInteractiveGuideline !== undefined) {
        chart.useInteractiveGuideline(false);
    }
    chartWidget.emptyChart = false;
};

renderChartHtml = function (chartWidget, chartType) {

    var chartTitleStyle = TW.getStyleFromStyleDefinition(chartWidget.getProperty('ChartTitleStyle', 'DefaultChartTitleStyle'));

    if (chartWidget.getProperty('ChartTitleStyle') !== undefined) {
        chartWidget.chartTitleTextSizeClass = TW.getTextSizeClassName(chartTitleStyle.textSize);
    }

    chartWidget.id = chartWidget.getProperty('Id');

    var html =
        '<div class="' + chartType + '-content widget-' + chartType +'" id="' + chartWidget.jqElementId + '"' +
        ' style="z-index:'+chartWidget.zIndex +';" > ' +
            '<div class="chart-title ' + chartWidget.chartTitleTextSizeClass + '" id="' +
             chartWidget.jqElementId + '-title" style="text-align:' + (chartWidget.titleAlignment || 'center') + ';">' +
                '<span class="widget-chart-title-text" style="Margin: 0 1em 0 1em;">'+ Encoder.htmlEncode(chartWidget.title) +
                '</span>' +
            '</div>' +
        '</div>';

        chartWidget.renderStyles();

    return html;
};

chartResize = function (chartWidget, chartId, isHidden){
    if ($(chartId).closest('.tabsv2-actual-tab-contents').css('display')==='block' && isHidden) {
        chartWidget.processDataset();
    }
    $(chartId).fadeIn(chartWidget.duration);
    return isHidden;
};