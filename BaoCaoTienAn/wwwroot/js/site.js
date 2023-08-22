$(document).ready(() => {

    function formatCurrency(value) {
        return value.toLocaleString('vi-VN');
    }

    function convertDate(date) {
        var date = new Date(date);
        var day = date.getDate();
        var month = date.getMonth() + 1;
        var year = date.getFullYear();
        var formattedDate = day + '-' + month + '-' + year;
        return formattedDate;
    }

    function bindDataTable(data = []) {
        let row = '';
        data.forEach((data) => {
            row += `<tr>`
            row += `<td>${convertDate(data.date)}</td>`
            row += `<td>${formatCurrency(data.tienAnSang)}</td>`
            row += `<td>${formatCurrency(data.tienAnTrua)}</td>`
            row += `<td>${formatCurrency(data.tienAnChieu)}</td>`
            row += `<td>${formatCurrency(data.phuPhi)}</td>`
            row += `<tr>`
        })
        $('#report-table > tbody').html(row)
    }

    function GetMealMoney(schoolId, startDate, endDate) {
        $.ajax({
            url: `/api/Report/GetMealMoney?schoolId=${schoolId}&startDate=${startDate}&endDate=${endDate}`,
            beforeSend: () => {
                $('#loading').removeClass('visually-hidden')
            },
            complete: () => {
                $('#loading').addClass('visually-hidden')
            },
            success: (data) => {
                $('#report-table').removeClass('visually-hidden')
                bindDataTable(data)
            }
        })
    }

    function ExportToExcel(schoolId, startDate, endDate) {
        window.open(`/api/Report/ExportToExcel/?schoolId=${schoolId}&startDate=${startDate}&endDate=${endDate}`, '_blank')
    }

    function ExportToXml(schoolId, startDate, endDate) {
        window.open(`/api/Report/ExportToXml/?schoolId=${schoolId}&startDate=${startDate}&endDate=${endDate}`, '_blank')
    }


    $('#search-btn').on('click', () => {
        const schoolId = $('#school-id').val()
        const startDate = $('#start-date-input').val()
        const endDate = $('#end-date-input').val()
        GetMealMoney(schoolId, startDate, endDate)
    })

    $('#export-excel-btn').on('click', () => {
        const schoolId = $('#school-id').val().trim()
        const startDate = $('#start-date-input').val().trim()
        const endDate = $('#end-date-input').val().trim()
        if (schoolId.length > 0 & startDate.length > 0 & endDate.length > 0) {
            ExportToExcel(schoolId, startDate, endDate)
        }
    })

    $('#export-xml-btn').on('click', () => {
        const schoolId = $('#school-id').val().trim()
        const startDate = $('#start-date-input').val().trim()
        const endDate = $('#end-date-input').val().trim()
        if (schoolId.length > 0 & startDate.length > 0 & endDate.length > 0) {
            ExportToXml(schoolId, startDate, endDate)
        }
    })
})
