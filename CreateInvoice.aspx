<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Associative.Master" AutoEventWireup="true" CodeBehind="CreateInvoice.aspx.cs" Inherits="Entrebator.Associative.CreateInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Associatmstr" runat="server">
    <style type="text/css">
        /*body {
            font-size: 16px;
            line-height: 25px;
            padding-top: 50px;
            font-family: 'Varela Round', sans-serif;
            background-color: #e7e7e7;
            padding-bottom: 50px;
        }*/

        .color-invoice {
            background-color: #ffffff;
            border: 1px solid #d7d7d7;
            padding-top: 100px;
            padding-bottom: 100px;
        }
    </style>

    <div class="row">
        <div class="col-md-12 text-center">
            <h1>Create Proforma Invoice</h1>
            <br />
        </div>
        <div class="row color-invoice">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="col-lg-7 col-md-7 col-sm-7">
                            <%--<p>
                                <img src="http://etr.rsosbiz.com/Documents/Common/Entrebator1.png" style="height: 88px; width: 94px; margin-left: -7px;" />
                            </p>--%>
                            <p><strong>Address:</strong>#121/30,15th Main,18th cross,</p>
                            <p>JP Nagar 5th Phase, Karnataka 560078.</p>
                            <%--<strong>GSTIN : </strong>29AABC07020L1ZA.--%>
                            <hr />
                            <div class="col-lg-5 col-md-5 col-sm-5">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="col-lg-6 col-md-6 col-sm-6">

                            <input class="form-control" type="text" placeholder="Enter Name" id="txtName" />


                            <input class="form-control" type="text" placeholder="Enter Email" id="txtEmail" />


                            <input class="form-control" type="text" placeholder="Enter Mobile" id="txtMobile" maxlength="10" />
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">

                            <input class="form-control" type="text" id="Invoicedate" placeholder="Enter  Date" readonly="true" />

                            <input class="form-control" type="text" placeholder="Enter GST" id="txtCGST" />

                            <textarea class="form-control" placeholder="Enter Address(or)Company's Name" id="txtAddress" style="height: 34px; resize: none"></textarea>
                        </div>

                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="col-lg-3 col-md-3 col-sm-3">
                            <select id="ddlInvoiceFor" class="form-control" onchange="return GetdetailsInvoiceFor();">
                                <option value="0">--Select Invoice For</option>
                                <option value="1">Event</option>
                                <option value="2">MemberShip</option>
                            </select>

                        </div>
                        <div class="col-lg-8 col-md-8 col-sm-8">
                            <select id="dddinvoicefor" class="form-control" onchange="return Getdetails()"></select>

                        </div>


                    </div>

                </div>
                <div class="row" style="margin-top: 10px">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="col-lg-3 col-md-3 col-sm-3">
                            <input type="radio" class="rdido" name="invrtype" checked="checked" value="1" onclick="return Paymetntypes();" />Proforma Invoice

                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-3">

                            <input type="radio" class="rdido"  name="invrtype" value="2" onclick="return Paymetntypes();" />Receipt Invoice
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <select id="ddlpaymenttypes" class="form-control" style="display: none" onchange="return PaymentRecipttype();">
                                <option value="0">--Select Payment Type</option>
                                <option value="1">Cash</option>
                                <option value="2">Cheque</option>
                                <option value="3">NEFT/RTGS</option>
                                <option value="4">Paytm</option>
                                <option value="5">CheqEzeTapue</option>
                            </select>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="table-responsive">
                            <table class="table table-striped ">
                                <thead>
                                    <tr>
                                        <th style="width: 3%">S.No.</th>
                                        <th style="width: 45%">Description</th>
                                        <th style="width: 5%">Quantity.</th>
                                        <th style="width: 7%">Unit Price</th>
                                        <th style="width: 7%">Sub Total</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="width: 3%">
                                            <input class="form-control" type="text" disabled="disabled" id="txtInvoice" /></td>
                                        <td style="width: 45%">
                                            <input class="form-control" type="text" id="txtdescription" /></td>
                                        <td style="width: 5%">
                                            <input class="form-control" type="text" id="txtQuantity" onblur="return OnblurCalculate();" /></td>
                                        <td style="width: 7%">
                                            <input class="form-control" type="text" id="txtAmount" onblur="return OnblurCalculate();" />
                                        </td>
                                        <td style="width: 7%">
                                            <input class="form-control" type="text" disabled="disabled" id="txtActualPrice" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="4">
                                            <label>
                                                Discount (%)
                                            </label>
                                        </td>
                                        <td>
                                            <input type="text" id="txtDiscount" class="form-control" onblur="return OnblurCalculate();" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="4">
                                            <label>Discounted Price </label>
                                        </td>
                                        <td>
                                            <label id="lblDiscAmount">00.00</label></td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="4">
                                            <label>Amount Before GST </label>
                                        </td>
                                        <td>
                                            <label id="lblBeforeTaxAmount">00.00</label></td>
                                    </tr>

                                    <tr>
                                        <td align="right" colspan="4">
                                            <label>CGST Tax(9%)</label>
                                        </td>
                                        <td>
                                            <label id="lblCGST">00.00</label></td>
                                    </tr>

                                    <tr>
                                        <td align="right" colspan="4">
                                            <label>SGST Tax(9%)</label>
                                        </td>
                                        <td>
                                            <label id="lblSGST">00.00</label></td>
                                    </tr>

                                    <tr>
                                        <td align="right" colspan="4">
                                            <label>IGST Tax(0%)</label>
                                        </td>
                                        <td>
                                            <label id="lblIGST">00.00</label></td>
                                    </tr>

                                    <tr>
                                        <td align="right" colspan="4">
                                            <label>Total</label>
                                        </td>
                                        <td>
                                            <label id="lblFinalAmount">00.00</label></td>
                                    </tr>
                                </tbody>
                            </table>


                        </div>
                        <div class="cols-sm-10">
                            <div class="form-group">
                                <label for="name" class="cols-sm-2 control-label">Terms And Conditions</label>
                                <div class="cols-sm-10">
                                    <textarea class="form-control" placeholder="Terms And Contidion" cols="100" id="txtTerms" style="height: 34px; resize: none"> </textarea>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">

                            <div class="col-lg-12 col-md-12 col-sm-12" style="text-align: center">
                                <input type="button" class="btn btn-primary" value="Create Invoice" style="width: 390px;" onclick="return CreateInvoice();" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myReceptModal" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="">Payment Details</h4>
                </div>
                <div class="modal-body">
                    <div class="tab-content col-md-12">
                        <div class="row">
                            <fieldset>

                                <!-- Form Name -->
                                <br />
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="col-md-2 control-label" for="fn">Amount</label>
                                        <div class="col-md-4">
                                            <input id="txtChequeAmount" name="fn" type="text" placeholder="Amount" class="form-control input-md" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">

                                    <div class="form-group">
                                        <label class="col-md-2 control-label" for="fn">Payment Date</label>
                                        <div class="col-md-4">
                                            <input id="txtCheQueDate" name="fn" type="text" placeholder="Payment Date" class="form-control input-md" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="col-md-2 control-label" for="fn">Transaction No</label>
                                        <div class="col-md-4">
                                            <input id="txtChqueNo" name="fn" type="text" placeholder="Transaction No" class="form-control input-md" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="col-md-2 control-label" for="fn">Bank Details</label>
                                        <div class="col-md-4">
                                            <input id="txtBankName" name="fn" type="text" placeholder="Bank Details" class="form-control input-md" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">

                                    <div class="form-group">
                                        <label class="col-md-2 control-label" for="fn">Collected By</label>
                                        <div class="col-md-4">
                                            <input id="txtChequeCollected" name="fn" type="text" placeholder="Collected By" class="form-control input-md" />
                                        </div>
                                    </div>
                                </div>
                                <%-- <div class="form-group">
                                        <label class="col-md-4 control-label" for="submit"></label>
                                        <div class="col-md-4">
                                            <button name="submit" class="btn btn-primary" onclick="return ChequePayment();">SUBMIT</button>
                                        </div>
                                    </div>--%>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" id="modalsmall" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog" style="padding-top: 180px; padding-left: 270px;">
            <div class="form-group">
                <img src="../Documents/Common/3.GIF" />
            </div>
        </div>
    </div>
    <script src="../Scripts/jquery-2.1.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var MemberID = getParameterByName("id");
            if (MemberID !== "") {
                EB_GetUserDetails();
            }
            else {

            }
            var pickerOpts =
                {
                    minDate: new Date(),
                    pickTime: false,
                    dateFormat: 'dd-M-yy',
                    showButtonPanel: true,
                    showAnim: ''
                };

            $("#Invoicedate,#txtCheQueDate").datetimepicker(pickerOpts);
            var currentDate = new Date();
            currentDate = moment(currentDate).format('l');
            $('#Invoicedate').val(currentDate);
            $("#txtMobile,#txtQuantity,#txtAmount,#txtDiscount").keydown(numberOnly);


        });
        function GetdetailsInvoiceFor() {
            var selval = $('#ddlInvoiceFor option:selected').val();
            if (selval == 0) {
                clearvalues();
                return false;
            }
            else if (selval == 1) {
                $.ajax({
                    url: "CreateInvoice.aspx/EB_Fetch_GetFutureEvents",
                    type: "POST",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#dddinvoicefor').empty();
                        var d = JSON.parse(data.d);
                        var s = "<option value= 0>-- Select --</option> ";
                        $.each(d, function (i, item) {
                            s = s + "<option value=" + item.EventID + ">" + item.EventName.trim() + "</option>";
                        });
                        $('#dddinvoicefor').empty().append(s);
                    },
                    error: function (xhr, status, error) {
                        var err = eval("(" + xhr.responseText + ")");
                        console.log(err.Message);
                        swal('Something went wrong, please try after some time!');
                    }
                });
            }
            else if (selval == 2) {
                $.ajax({
                    url: "CreateInvoice.aspx/EB_Fetch_ETRMemberShips",
                    type: "POST",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#dddinvoicefor').empty();
                        var d = JSON.parse(data.d);
                        var opt = "<option value= 0 >---Select---</option>";
                        $.each(d, function (i, item) {

                            opt = opt + "<option value=" + item.MembershipID + " >" + item.MembershipName.trim() + "</option>";
                        });
                        $('#dddinvoicefor').append(opt);
                    },
                    error: function (xhr, status, error) {
                        var err = eval("(" + xhr.responseText + ")");
                        console.log(err.Message);
                        swal('Something went wrong, please try after some time!');
                    }
                });
            }
        }
        function Getdetails() {
            var selval = $('#ddlInvoiceFor option:selected').val();
            var Selectdval = $('#dddinvoicefor option:selected').val();

            if (Selectdval == 0) {
                clearvalues();
                return false;
            }
            else if (Selectdval == 0) {
                clearvalues();
                return false;
            }
            else if (selval == 1) {
                $.ajax({
                    url: "CreateInvoice.aspx/EB_Fetch_GetFutureEventsByEventID",
                    type: "POST",
                    data: "{'EventID':'" + Selectdval + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var d = JSON.parse(data.d);
                        var s = "<option value= 0>-- Select --</option> ";
                        $.each(d, function (i, item) {
                            var txt = item.EventName;
                            $("#txtInvoice").val(1);
                            $("#txtdescription").val(txt);
                            $("#txtQuantity").val(1);
                            $("#txtAmount").val(item.Amount);
                            $("#txtActualPrice").val(item.Amount);
                        });

                    },
                    complete: function (data) {
                        OnblurCalculate();
                    },
                    error: function (xhr, status, error) {
                        var err = eval("(" + xhr.responseText + ")");
                        console.log(err.Message);
                        swal('Something went wrong, please try after some time!');
                    }
                });
            }
            else if (selval == 2) {
                $.ajax({
                    url: "CreateInvoice.aspx/EB_Fetch_ETRMemberShipsByMembershipID",
                    type: "POST",
                    data: "{'MembershipID':'" + Selectdval + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var d = JSON.parse(data.d);
                        $.each(d, function (i, item) {
                            var txt = item.MembershipName;
                            $("#txtInvoice").val(1);
                            $("#txtdescription").val(txt);
                            $("#txtQuantity").val(1);
                            $("#txtAmount").val(item.Amount);
                            $("#txtActualPrice").val(item.Amount);
                        });

                    },
                    complete: function (data) {
                        OnblurCalculate();
                    },
                    error: function (xhr, status, error) {
                        var err = eval("(" + xhr.responseText + ")");
                        console.log(err.Message);
                        swal('Something went wrong, please try after some time!');
                    }
                });
            }
        }
        function numberOnly(e) {
            // Allow: backspace, delete, tab, escape, enter and .
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                // Allow: Ctrl+A
                (e.keyCode == 65 && e.ctrlKey === true) ||
                // Allow: home, end, left, right
                (e.keyCode >= 35 && e.keyCode <= 39)) {
                // let it happen, don't do anything
                return;
            }
            // Ensure that it is a number and stop the keypress
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        }

        function clearvalues() {
            $("#txtInvoice").val('');
            $("#txtdescription").val('');
            $("#txtQuantity").val('');
            $("#txtAmount").val('');
            $("#txtActualPrice").val('');
            $("#txtDiscount").val('');
            $("#lblDiscAmount").text('');
            $("#lblBeforeTaxAmount").text('');
            $("#lblCGST").text('');
            $("#lblSGST").text('');
            $("#lblFinalAmount").text('');
            $("#ddlInvoiceFor option[value='0']").attr('selected', true)
            $("#dddinvoicefor").empty().append('<option value= 0>-- Select --</option>');
            ClearAmountValues();

        }
        function ClearAmountValues() {
            $("#txtDiscount").val('');
            $("#lblDiscAmount").text('');
            $("#lblBeforeTaxAmount").text('');
            $("#lblCGST").text('');
            $("#lblSGST").text('');
            $("#lblFinalAmount").text('');
        }
        function OnblurCalculate() {

            var selval = $('#ddlInvoiceFor option:selected').val();
            //if (selval == 1)
            //{
            //    OnblurCalculateEvent();
            //}
            //else
            //{
            var Quantity = $("#txtQuantity").val();
            var Amount = $("#txtAmount").val();
            var Discount = $("#txtDiscount").val();
            var amt = "";
            if (Quantity == "") {
                ClearAmountValues();
                return false;
            }
            else if (Amount == "") {
                ClearAmountValues();
                return false;
            }
            else if (Discount >= 100) {
                ClearAmountValues();
                swal('Percentage Should be with in 100');
            }
            else {

                amt = Amount * Quantity;
                // amt = Math.round(amt);
                $("#txtActualPrice").val(amt);
                if (Discount != "" && Discount !== 0) {
                    var disPrice = (amt * Discount) / 100;
                    disPrice = disPrice.toFixed(2);
                    disPrice = Math.round(disPrice);
                    $("#txtDiscount").val(Discount);
                    $("#lblDiscAmount").text(disPrice);
                    var BeforeTax = amt - disPrice;
                    BeforeTax = BeforeTax.toFixed(2);
                    BeforeTax = Math.round(BeforeTax);
                    $("#lblBeforeTaxAmount").text(BeforeTax);
                    var tTax = (BeforeTax / 100) * 18.00;
                    // tTax = Math.round(tTax);
                    var GST = tTax / 2;
                    GST = Math.round(GST);
                    $("#lblCGST").text(GST);
                    $("#lblSGST").text(GST);
                    var FinalAmount = BeforeTax + tTax;
                    FinalAmount = Math.round(FinalAmount);
                    $("#lblFinalAmount").text(FinalAmount);
                }
                else {
                    $("#lblBeforeTaxAmount").text(amt);
                    var tTax = (amt / 100) * 18.00;
                    // tTax = Math.round(tTax);
                    var GST = tTax / 2;
                    GST = Math.round(GST);
                    $("#lblCGST").text(GST);
                    $("#lblSGST").text(GST);
                    var FinalAmount = amt + tTax;
                    FinalAmount = Math.round(FinalAmount);
                    $("#lblFinalAmount").text(FinalAmount);
                }
            }
        }
        //  }

        function ClearPerformaInvoice() {
            $("#txtName").val('');
            $("#txtEmail").val('');
            $("#txtMobile").val('');
            $("#txtAddress").val('');
            $("#txtCGST").val('');
            $("#Invoicedate").val('');
            $("#txtInvoice").val('');
            $("#txtQuantity").val('');
            $("#txtdescription").val('');
            $("#txtActualPrice").val('');
            $("#txtDiscount").val('');
            $("#ddlInvoiceFor option[value='0']").attr('selected', true)
            $("#dddinvoicefor").empty().append('<option value= 0>-- Select --</option>');
            $('#txtTerms').val('');
            $('[name="invrtype"]').removeAttr('checked');
           // $("input[name=invrtype][value='1']").attr('checked', 'checked');
            $("#ddlpaymenttypes option[value='0']").attr('selected', true);
            $('input:radio[class=rdido][value="1"]').prop('checked', true);
            $("#ddlpaymenttypes").hide();
            $("#txtChequeAmount").val('');
            $("#txtCheQueDate").val('');
            $("#txtChqueNo").val('');
            $("#txtBankName").val('');
            $("#txtChequeCollected").val('');
        }
        function CreateInvoice() {
            var type = $("input[name='invrtype']:checked").val();
            if (type == 1) {
                CreatePerformaInvoice();
            }
            else {
                CreateReceiptInvoice();
            }
        }
        function CreatePerformaInvoice() {

            var MID = "";
            var txtName = $("#txtName").val();
            var txtEmail = $("#txtEmail").val();
            var txtMobile = $("#txtMobile").val();
            var txtAddress = $("#txtAddress").val();
            var txtClientGST = $("#txtCGST").val();
            var txtInvoiceDate = $("#Invoicedate").val();
            // txtInvoiceDate = new Date(txtInvoiceDate);
            var txtInvoice = $("#txtInvoice").val();
            var txtQuantity = $("#txtQuantity").val();
            var txtdescription = $("#txtdescription").val();
            var txtActualPrice = $("#txtActualPrice").val();
            var txtDiscount = $("#txtDiscount").val();
            var lblDiscAmount = $("#lblDiscAmount").text();
            var lblBeforeTaxAmount = $("#lblBeforeTaxAmount").text();
            var lblCGST = $("#lblCGST").text();
            var lblSGST = $("#lblSGST").text();
            var lblIGST = 0;;
            var lblFinalAmount = $("#lblFinalAmount").text();
            var InvoiceFor = $('#ddlInvoiceFor option:selected').val();
            var UIDFor = $('#dddinvoicefor option:selected').val();
            var txtTerms = $('#txtTerms').val();
            if (txtName === "") {
                $("#txtName").focus();
                return false;
            }
            if (txtEmail === "") {
                $("#txtEmail").focus();
                return false;
            }
            var MEMID = getParameterByName("id");
            if (MEMID !== "") {
                MID = getParameterByName("id");
            }
            else {
                MID = "00000000-0000-0000-0000-000000000000";
            }
            if (txtEmail !== "") {
                var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
                if (reg.test(txtEmail) == false) {
                    swal('Invalid Email Address');
                    $("#txtEmail").focus();
                    return false;
                }
            }
            if (txtMobile === "") {
                $("#txtMobile").focus();
                return false;
            }
            if (txtMobile !== "") {
                var re = /^[1-9]{1}[0-9]{9}$/;
                if (re.test(txtMobile) == false) {
                    swal('Invalid  Mobile Number');
                    $("#txtMobile").focus();
                    return false;
                }
            }
            if (txtAddress === "") {
                $("#txtAddress").focus();
                return false;
            }
            if (txtInvoiceDate === "") {
                $("#txtInvoiceDate").focus();
                return false;
            }
            if (InvoiceFor === "" && InvoiceFor == 0) {
                $("#InvoiceFor").focus();
                return false;
            }
            if (UIDFor === "" && UIDFor == 0) {
                $("#UIDFor").focus();
                return false;
            }
            if (txtInvoice === "") {
                $("#txtInvoice").focus();
                return false;
            }
            if (txtQuantity === "") {
                $("#txtQuantity").focus();
                return false;
            }
            if (txtdescription === "") {
                $("#txtdescription").focus();
                return false;
            }
            if (txtActualPrice === "" && txtActualPrice == 0) {
                $("#txtActualPrice").focus();
                return false;
            }
            if (txtDiscount === "") {
                txtDiscount = 0;
            }
            if (lblDiscAmount === "00.00") {
                lblDiscAmount = 0;
            }
            if (lblBeforeTaxAmount === "" && lblBeforeTaxAmount == 0) {
                $("#lblBeforeTaxAmount").focus();
                return false;
            }
            if (lblCGST === "" && lblCGST == 0) {
                $("#lblCGST").focus();
                return false;
            }
            if (lblSGST === "" && lblSGST == 0) {
                $("#lblSGST").focus();
                return false;
            }
            if (lblIGST === "" && lblIGST == 0) {
                $("#lblIGST").focus();
                return false;
            }
            if (lblFinalAmount === "" && lblFinalAmount == 0) {
                $("#lblFinalAmount").focus();
                return false;
            }
            var data = {};
            var d = new Date();
            data.Name = txtName;
            data.Email = txtEmail;
            data.Mobile = txtMobile;
            data.Address = txtAddress;
            data.InvoiceDate = txtInvoiceDate;
            data.Invoice = txtInvoice;
            data.Quantity = txtQuantity;
            data.MemberID = MID;
            data.Description = txtdescription;
            data.ActualPrice = txtActualPrice;
            data.Discount = txtDiscount;
            data.DiscAmount = lblDiscAmount;
            data.TaxAmount = parseInt(lblCGST) + parseInt(lblSGST);
            data.BeforeTaxAmount = lblBeforeTaxAmount;
            data.CGST = lblCGST;
            data.SGST = lblSGST;
            data.IGST = lblIGST;
            data.FinalAmount = lblFinalAmount;
            data.InvoiceFor = InvoiceFor;
            data.UIDFor = UIDFor;
            data.CreatedOn = d;
            data.Terms = txtTerms;
            data.ClientGST = txtClientGST;
            data = JSON.stringify(data);
            var obj1 = {};
            obj1.obj = data;
            obj1 = JSON.stringify(obj1);
            $("#modalsmall").modal("show");
            $.ajax({
                url: "CreateInvoice.aspx/InsertProformaInvoices",
                type: "POST",
                data: obj1,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {

                    if (data.d != 0) {
                        $("#modalsmall").modal("hide");
                        swal("Success");
                        ClearPerformaInvoice();
                        clearvalues();
                    }
                },
                error: function (xhr, error, status) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }

        function CreateReceiptInvoice() {
            var PaymentMode = $("#ddlpaymenttypes option:selected").val();
            if (PaymentMode == '0') {
                swal("Please Select Payment Mode");
                return false;
            }
            var ChequeAmount = $("#txtChequeAmount").val();
            var ChequeDate = $("#txtCheQueDate").val();
            var ChequeNo = $("#txtChqueNo").val();
            var BankDetails = $("#txtBankName").val();
            var CollectedBy = $("#txtChequeCollected").val();
            if (ChequeAmount == '' || ChequeAmount == 0) {
                $("#myReceptModal").modal("show");
                return false;
            }
            if (ChequeDate == '' || ChequeAmount == undefined) {
                $("#myReceptModal").modal("show");
                return false;
            }
            if (ChequeNo == '' || ChequeNo == undefined) {
                $("#myReceptModal").modal("show");
                return false;
            }
            var MID = "";
            var txtName = $("#txtName").val();
            var txtEmail = $("#txtEmail").val();
            var txtMobile = $("#txtMobile").val();
            var txtAddress = $("#txtAddress").val();
            var txtClientGST = $("#txtCGST").val();
            var txtInvoiceDate = $("#Invoicedate").val();
            // txtInvoiceDate = new Date(txtInvoiceDate);
            var txtInvoice = $("#txtInvoice").val();
            var txtQuantity = $("#txtQuantity").val();
            var txtdescription = $("#txtdescription").val();
            var txtActualPrice = $("#txtActualPrice").val();
            var txtDiscount = $("#txtDiscount").val();
            var lblDiscAmount = $("#lblDiscAmount").text();
            var lblBeforeTaxAmount = $("#lblBeforeTaxAmount").text();
            var lblCGST = $("#lblCGST").text();
            var lblSGST = $("#lblSGST").text();
            var lblIGST = 0;;
            var lblFinalAmount = $("#lblFinalAmount").text();
            var InvoiceFor = $('#ddlInvoiceFor option:selected').val();
            var UIDFor = $('#dddinvoicefor option:selected').val();
            var txtTerms = $('#txtTerms').val();
            if (txtName === "") {
                $("#txtName").focus();
                return false;
            }
            if (txtEmail === "") {
                $("#txtEmail").focus();
                return false;
            }
            var MEMID = getParameterByName("id");
            if (MEMID !== "") {
                MID = getParameterByName("id");
            }
            else {
                MID = "00000000-0000-0000-0000-000000000000";
            }
            if (txtEmail !== "") {
                var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
                if (reg.test(txtEmail) == false) {
                    swal('Invalid Email Address');
                    $("#txtEmail").focus();
                    return false;
                }
            }
            if (txtMobile === "") {
                $("#txtMobile").focus();
                return false;
            }
            if (txtMobile !== "") {
                var re = /^[1-9]{1}[0-9]{9}$/;
                if (re.test(txtMobile) == false) {
                    swal('Invalid  Mobile Number');
                    $("#txtMobile").focus();
                    return false;
                }
            }
            if (txtAddress === "") {
                $("#txtAddress").focus();
                return false;
            }
            if (txtInvoiceDate === "") {
                $("#txtInvoiceDate").focus();
                return false;
            }
            if (InvoiceFor === "" && InvoiceFor == 0) {
                $("#InvoiceFor").focus();
                return false;
            }
            if (UIDFor === "" && UIDFor == 0) {
                $("#UIDFor").focus();
                return false;
            }
            if (txtInvoice === "") {
                $("#txtInvoice").focus();
                return false;
            }
            if (txtQuantity === "") {
                $("#txtQuantity").focus();
                return false;
            }
            if (txtdescription === "") {
                $("#txtdescription").focus();
                return false;
            }
            if (txtActualPrice === "" && txtActualPrice == 0) {
                $("#txtActualPrice").focus();
                return false;
            }
            if (txtDiscount === "") {
                txtDiscount = 0;
            }
            if (lblDiscAmount === "00.00") {
                lblDiscAmount = 0;
            }
            if (lblBeforeTaxAmount === "" && lblBeforeTaxAmount == 0) {
                $("#lblBeforeTaxAmount").focus();
                return false;
            }
            if (lblCGST === "" && lblCGST == 0) {
                $("#lblCGST").focus();
                return false;
            }
            if (lblSGST === "" && lblSGST == 0) {
                $("#lblSGST").focus();
                return false;
            }
            if (lblIGST === "" && lblIGST == 0) {
                $("#lblIGST").focus();
                return false;
            }
            if (lblFinalAmount === "" && lblFinalAmount == 0) {
                $("#lblFinalAmount").focus();
                return false;
            }
            var data = {};
            var d = new Date();
            data.Name = txtName;
            data.Email = txtEmail;
            data.Mobile = txtMobile;
            data.Address = txtAddress;
            data.InvoiceDate = txtInvoiceDate;
            data.Invoice = txtInvoice;
            data.Quantity = txtQuantity;
            data.MemberID = MID;
            data.Description = txtdescription;
            data.ActualPrice = txtActualPrice;
            data.Discount = txtDiscount;
            data.DiscAmount = lblDiscAmount;
            data.TaxAmount = parseInt(lblCGST) + parseInt(lblSGST);
            data.BeforeTaxAmount = lblBeforeTaxAmount;
            data.CGST = lblCGST;
            data.SGST = lblSGST;
            data.IGST = lblIGST;
            data.FinalAmount = lblFinalAmount;
            data.InvoiceFor = InvoiceFor;
            data.UIDFor = UIDFor;
            data.CreatedOn = d;
            data.Terms = txtTerms;
            data.ClientGST = txtClientGST;
            data.ChequeAmount = ChequeAmount;
            data.ChequeNo = ChequeNo;
            data.ChequeDate = ChequeDate;
            data.BankDetails = BankDetails;
            data.CollectedBy = CollectedBy;
            data.PaymentMode = PaymentMode;
            data = JSON.stringify(data);
            var obj1 = {};
            obj1.obj = data;
            obj1 = JSON.stringify(obj1);
            $("#modalsmall").modal("show");
            $.ajax({
                url: "CreateInvoice.aspx/InsertReceiptInvoices",
                type: "POST",
                data: obj1,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {

                    if (data.d != 0) {
                        $("#modalsmall").modal("hide");
                        swal("Success");
                        ClearPerformaInvoice();
                        clearvalues();
                    }
                },
                error: function (xhr, error, status) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }

        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }
        function EB_GetUserDetails() {
            var Memb = getParameterByName("id");
            $.ajax({
                url: "CreateInvoice.aspx/EB_GetUserDetails",
                type: "POST",
                data: "{'UserID':'" + Memb + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var dt = data.d;
                    $("#txtName").val(dt.Name);
                    $("#txtEmail").val(dt.Email);
                    $("#txtMobile").val(dt.Mobile);
                    $("#txtAddress").val(dt.Address);
                },
                error: function (xhr, status, error) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        //function OnblurCalculateEvent()
        //{
        //    var Quantity = $("#txtQuantity").val();
        //    var Amount = $("#txtAmount").val();
        //    var Discount = $("#txtDiscount").val();
        //    var amt = "";
        //    if (Quantity == "") {
        //        ClearAmountValues();
        //        return false;
        //    }
        //    else if (Amount == "") {
        //        ClearAmountValues();
        //        return false;
        //    }
        //    else if (Discount >= 100) {
        //        ClearAmountValues();
        //        swal('Percentage Should be with in 100');
        //    }
        //    else {

        //        amt = Amount * Quantity;
        //        amt = Math.round(amt);
        //        $("#txtActualPrice").val(amt);
        //        if (Discount != "" && Discount !== 0) {
        //            var disPrice = (amt * Discount) / 100;
        //            disPrice = disPrice.toFixed(2);
        //            disPrice = Math.round(disPrice);
        //            $("#txtDiscount").val(Discount);
        //            $("#lblDiscAmount").text(disPrice);
        //            var BeforeTax = amt - disPrice;
        //            BeforeTax = BeforeTax.toFixed(2);
        //            BeforeTax = Math.round(BeforeTax);
        //            $("#lblBeforeTaxAmount").text(BeforeTax);
        //           // var tTax = (BeforeTax / 100) * 18.00;
        //            var tTax = 0;
        //            tTax = Math.round(tTax);
        //            var GST = tTax / 2;
        //            GST = Math.round(GST);
        //            $("#lblCGST").text(GST);
        //            $("#lblSGST").text(GST);
        //           var FinalAmount = BeforeTax + tTax;
        //            //FinalAmount = Math.round(FinalAmount);
        //            $("#lblFinalAmount").text(FinalAmount);
        //        }
        //        else {
        //            $("#lblBeforeTaxAmount").text(amt);
        //         //   var tTax = (amt / 100) * 18.00;
        //            var tTax = 0;
        //            tTax = Math.round(tTax);
        //            var GST = tTax / 2;
        //            GST = Math.round(GST);
        //            $("#lblCGST").text(GST);
        //            $("#lblSGST").text(GST);
        //            var FinalAmount = amt + tTax;
        //           // FinalAmount = Math.round(FinalAmount);
        //            $("#lblFinalAmount").text(FinalAmount);
        //        }

        //    }
        //}
        function Paymetntypes() {
            var type = $("input[name='invrtype']:checked").val();
            if (type == 1) {
                $("#ddlpaymenttypes").hide();
                $("#ddlpaymenttypes option[value='0']").attr('selected', true)
            }
            else {
                $("#ddlpaymenttypes").show();
            }
        }
        function PaymentRecipttype() {
            var paymentmode = $("#ddlpaymenttypes option:selected").val();
            if (paymentmode != 0) {
                $("#myReceptModal").modal("show");
            }
        }
    </script>

</asp:Content>
