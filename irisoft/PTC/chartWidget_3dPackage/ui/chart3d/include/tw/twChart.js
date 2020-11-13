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

simpleRenderGraph = function {
	

Plotly.d3.csv('https://raw.githubusercontent.com/plotly/datasets/master/api_docs/mt_bruno_elevation.csv', function(err, rows){
	function unpack(rows, key) {
	  return rows.map(function(row) { return row[key]; });
	}
	var z_data=[ ]
	for(i=0;i<24;i++)
	{
	  z_data.push(unpack(rows,i));
	}
	
	var data = [{
	  z: z_data,
	  type: 'surface',
	  contours: {
	    z: {
	      show:true,
	      usecolormap: true,
	      highlightcolor:"#42f462",
	      project:{z: true}
	    }
	  }
	}];
	
	var layout = {
	  title: 'Mt Bruno Elevation With Projected Contours',
	  scene: {camera: {eye: {x: 1.87, y: 0.88, z: -0.64}}},
	  autosize: true,
	  width: 500,
	  height: 500,
	  margin: {
	    l: 65,
	    r: 50,
	    b: 65,
	    t: 90,
	  }
	};

Plotly.newPlot('chart', data, layout);	
	});        

}

chartResize = function (chartWidget, chartId, isHidden){
    if ($(chartId).closest('.tabsv2-actual-tab-contents').css('display')==='block' && isHidden) {
        chartWidget.processDataset();
    }
    $(chartId).fadeIn(chartWidget.duration);
    return isHidden;
};