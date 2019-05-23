var page = namespace("Manage.Index");

page.inventoryIndex = -1;

page.delete = function (id) {
    $.ajax({
        type: "DELETE",
        url: "/manage/inventorydelete?id=" + id,
        success: page.deleteSuccess,
        failure: page.deleteFailure,
    });
};

page.deleteSuccess = function (data) {
    $('#trInventory_' + data).remove();
};

page.deleteFailure = function () {

};


page.markAsSold = function (inventoryId) {
    var formArray = $('#ModalForm').serializeArray()
    var data = {};

    for (var i = 0; i < formArray.length; i++) {
        data[formArray[i]['name']] = formArray[i]['value'];
    }

    $.ajax({
        type: "POST",
        url: "/manage/salesinfo",
        data: data,
        success: page.markAsSoldSuccess
    });
};

page.markAsSoldSuccess = function () {
    var message = $('#ModelMessage')
    message.text('Inventory successfully updated')
    message.addClass('alert alert-success');
};

page.clearMessage = function () {
    var message = $('#ModelMessage')
    message.text('')
    message.removeClass('alert alert-success');
};

page.clearModal = function () {
    $('#ModalForm').find('input:not(#DateSold)').val('');
    $('#ModalForm').find('select').prop('selectedIndex', 0);
};

page.prevInventory = function () {
    page.clearMessage();
    page.clearModal();

    if (page.inventoryIndex >= data.inventory.length - 1)
        return;

    page.inventoryIndex += 1;
    var inventory = data.inventory[page.inventoryIndex];
    $('#ModalTitle').text(inventory.YMMString);
    $('#OPInventoryId').val(inventory.Id)
};

page.nextInventory = function () {
    page.clearMessage();
    page.clearModal();

    if (page.inventoryIndex <= 0)
        return;

    page.inventoryIndex -= 1;
    var inventory = data.inventory[page.inventoryIndex];
    $('#ModalTitle').text(inventory.YMMString);
    $('#OPInventoryId').val(inventory.Id)
};

page.setupCustomerModal = function (customer) {
    $("#FirstName").val(customer.FirstName);
    $("#LastName").val(customer.LastName);
    $("#Email").val(customer.Email);
    $("#PhoneNumber").val(customer.PhoneNumber);
    $("#Address").val(customer.Address);
    $("#City").val(customer.City);
    $("#State").val(customer.State);
    $("#Zip").val(customer.Zip);
};

page.setupSalesInfo = function (salesinfo) {
    $("#DealerEmployeeId").val(salesinfo.DealerEmployeeId);
    $("#PriceSold").val(salesinfo.PriceSold);
    $("#DateSold").val(moment(salesinfo.DateSold).format('MM/DD/YYYY'));
    $("#SalesType").val(salesinfo.SalesType);
};

"use strict";

/*****Ready function start*****/
$(document).ready(function () {
    $('.datepicker').datepicker({
        format: 'mm/dd/yyyy',
        startDate: '0d'
    });

    $('#metrics_table').DataTable({
        "bFilter": false,
        "bLengthChange": false,
        "bPaginate": false,
        "bInfo": false,
        "order": [[3, "desc"]]
    });
    if ($('#chart_risks').length > 0) {
        var ctx7 = document.getElementById("chart_risks").getContext("2d");
        var data7 = {
            labels: [
                "Low",
                "Medium",
                "High"
            ],
            datasets: [
                {
                    data: [300, 100, 50],
                    backgroundColor: [
                        "rgba(9,162,117,1)",
                        "rgba(242,183,1,1)",
                        "rgba(220,0,48,1)"
                    ],
                    hoverBackgroundColor: [
                        "rgba(9,162,117,1)",
                        "rgba(242,183,1,1)",
                        "rgba(220,0,48,1)"
                    ]
                }]
        };

        var doughnutChart = new Chart(ctx7, {
            type: 'doughnut',
            data: data7,
            options: {
                animation: {
                    duration: 2000
                },
                responsive: true,
                maintainAspectRatio: false,
                legend: {
                    labels: {
                        fontFamily: "Roboto",
                        fontColor: "#878787"
                    }
                },
                elements: {
                    arc: {
                        borderWidth: 0
                    }
                },
                tooltip: {
                    backgroundColor: 'rgba(33,33,33,1)',
                    cornerRadius: 0,
                    footerFontFamily: "'Roboto'"
                }
            }
        });
    }
    if ($('#chart_6').length > 0) {
        var ctx6 = document.getElementById("chart_6").getContext("2d");
        var data6 = {
            labels: [
                "Completed",
                "Delayed",
                "Overdue",
                "Not Started"
            ],
            datasets: [
                {
                    data: [300, 50, 100, 70],
                    backgroundColor: [
                        "rgba(9,162,117,1)",
                        "rgba(242,183,1,1)",
                        "rgba(220,0,48,1)",
                        "rgba(177,0,88,1)"
                    ],
                    hoverBackgroundColor: [
                        "rgba(9,162,117,1)",
                        "rgba(242,183,1,1)",
                        "rgba(220,0,48,1)",
                        "rgba(177,0,88,1)"
                    ]
                }]
        };

        var pieChart = new Chart(ctx6, {
            type: 'pie',
            data: data6,
            options: {
                animation: {
                    duration: 3000
                },
                responsive: true,
                maintainAspectRatio: false,
                legend: {
                    labels: {
                        fontFamily: "Roboto",
                        fontColor: "#878787"
                    }
                },
                tooltip: {
                    backgroundColor: 'rgba(33,33,33,1)',
                    cornerRadius: 0,
                    footerFontFamily: "'Roboto'"
                },
                elements: {
                    arc: {
                        borderWidth: 0
                    }
                }
            }
        });

        if ($('#ct_chart_1').length > 0) {
            new Chartist.Line('#ct_chart_1', {
                labels: [1, 2, 3, 4, 5, 6, 7, 8],
                series: [
                    [1, 2, 3, 1, -2, 0, 1, 0],
                    [-2, -1, -2, -1, -2.5, -1, -2, -1],
                    [0, 0, 0, 1, 2, 2.5, 2, 1],
                    [2.5, 2, 1, 0.5, 1, 0.5, -1, -2.5]
                ]
            }, {
                    high: 3,
                    low: -3,
                    showArea: true,
                    showLine: false,
                    showPoint: false,
                    fullWidth: true,
                    axisX: {
                        showLabel: false,
                        showGrid: false
                    }
                });
        }



        if ($('#ct_chart_3').length > 0) {
            new Chartist.Pie('#ct_chart_3', {
                series: [20, 10, 30, 40]
            }, {
                    donut: true,
                    donutWidth: 60,
                    startAngle: 270,
                    total: 200,
                    showLabel: true
                });
        }

        if ($('#ct_chart_4').length > 0) {
            new Chartist.Bar('#ct_chart_4', {
                labels: ['W1', 'W2', 'W3', 'W4', 'W5', 'W6', 'W7', 'W8', 'W9', 'W10'],
                series: [
                    [1, 2, 4, 8, 6, -2, -1, -4, -6, -2]
                ]
            },
                {
                    high: 10,
                    low: -10,
                    axisX: {
                        labelInterpolationFnc: function (value, index) {
                            return index % 2 === 0 ? value : null;
                        }
                    }
                });
        }

        if ($('#ct_chart_5').length > 0) {
            new Chartist.Bar('#ct_chart_5', {
                labels: ['First quarter of the year', 'Second quarter of the year', 'Third quarter of the year', 'Fourth quarter of the year'],
                series: [
                    [60000, 40000, 80000, 70000],
                    [40000, 30000, 70000, 65000],
                    [8000, 3000, 10000, 6000]
                ]
            }, {
                    seriesBarDistance: 10,
                    axisX: {
                        offset: 60
                    },
                    axisY: {
                        offset: 80,
                        labelInterpolationFnc: function (value) {
                            return value + ' CHF'
                        },
                        scaleMinSpace: 15
                    }
                });
        }

        if ($('#ct_chart_7').length > 0) {
            new Chartist.Bar('#ct_chart_7', {
                labels: ['Q1', 'Q2', 'Q3', 'Q4'],
                series: [
                    [800000, 1200000, 1400000, 1300000],
                    [200000, 400000, 500000, 300000],
                    [100000, 200000, 400000, 600000]
                ]
            }, {
                    stackBars: true,
                    axisY: {
                        labelInterpolationFnc: function (value) {
                            return (value / 1000) + 'k';
                        }
                    }
                }).on('draw', function (data) {
                    if (data.type === 'bar') {
                        data.element.attr({
                            style: 'stroke-width: 30px'
                        });
                    }
                });
        }
    }

    if ($('#chart_ytd').length > 0)
        // Morris bar chart
        Morris.Bar({
            element: 'chart_ytd',
            data: data.yearlyIntervals,
            xkey: ['MonthName'],
            ykeys: ['Total'],
            labels: ['Total'],
            barColors: ['#7293CB', '#E1974C', '#84BA5B', '#D35E60', '#808585', '#9067A7', '#AB6857', '#CCC210', '#84BA5B', '#7293CB', '#E1974C', '#84BA5B'],
            hideHover: 'auto',
            gridLineColor: '#878787',
            resize: true,
            barGap: 1,
            xLabelAngle: 35,
            gridTextColor: '#878787',
            gridTextFamily: "Roboto"
        });

    if ($('#chart_mtd').length > 0)
        Morris.Bar({
            element: 'chart_mtd',
            data: data.monthlyIntervals,
            xkey: ['Week'],
            ykeys: ['Total'],
            labels: ['Total'],
            barColors: ['#7293CB', '#E1974C', '#84BA5B', '#D35E60', '#808585'],
            hideHover: 'auto',
            gridLineColor: '#878787',
            resize: true,
            barGap: 1,
            xLabelAngle: 35,
            gridTextColor: '#878787',
            gridTextFamily: "Roboto"
        });

    $('#SaleModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var inventory = button.data('inventory') // Extract info from data-* attributes
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this)
        modal.find('.modal-title').text(inventory.YMMString);
        $('#OPInventoryId').val(inventory.Id);
        page.clearMessage();

        if (data.inventory) {
            var index = -1;

            for (var i = 0; i < data.inventory.length; i++) {
                if (data.inventory[i].Id == inventory.Id) {
                    page.inventoryIndex = i;
                    break;
                }
            }
        }

        if (inventory.Customers.length > 0)
            page.setupCustomerModal(inventory.Customers[0]);

        if (inventory.SalesInfo != null)
            page.setupSalesInfo(inventory.SalesInfo[0]);
    })
});
/*****Ready function end*****/

/*****Sparkline function start*****/
var sparklineInit = function () {
    if ($('#sparkline_4').length > 0) {
        $("#sparkline_4").sparkline(data.monthlyRevenue, {
            type: 'line',
            width: '100%',
            height: '90',
            lineColor: '#f2b701',
            fillColor: '#f2b701',
            maxSpotColor: '#f2b701',
            highlightLineColor: 'rgba(0, 0, 0, 0.2)',
            highlightSpotColor: '#f2b701'
        });
    }

    if ($('#div_yearly_revenue').length > 0) {
        $("#div_yearly_revenue").sparkline(data.yearlyRevenue, {
            type: 'line',
            width: '100%',
            height: '90',
            lineColor: '#f2b701',
            fillColor: '#f2b701',
            maxSpotColor: '#f2b701',
            highlightLineColor: 'rgba(0, 0, 0, 0.2)',
            highlightSpotColor: '#f2b701'
        });
    }
}

var sparkResize;
/*****Sparkline function end*****/

$(window).resize(function (e) {
    clearTimeout(sparkResize);
    sparkResize = setTimeout(sparklineInit, 200);
});
sparklineInit();