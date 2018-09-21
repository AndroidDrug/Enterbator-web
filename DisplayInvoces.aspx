<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Associative.Master" AutoEventWireup="true" CodeBehind="DisplayInvoces.aspx.cs" Inherits="Entrebator.Associative.DisplayInvoces" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Associatmstr" runat="server">
    <div class="bs-example">
        <div class="tab-content col-md-10">
            <ul class="nav nav-tabs ">
                <li class="active"><a href="#tab_a" data-toggle="pill">proforma invoice</a></li>
                <li><a href="#tab_b" data-toggle="pill" onclick="return EB_FetechPaidInvoices();">Paid invoice</a></li>
                <li><a href="#tab_c" data-toggle="pill" onclick="return EB_FetechproformaInvoices();">Pdf Excel</a></li>
            </ul>
        </div>
        <div class="tab-content col-md-12">
            <div class="tab-pane active" id="tab_a">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <h3 class="panel-title">proforma Invoices</h3>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <table id="tblinvoice" class="table table-bordered table-condensed table-hover table-responsive"></table>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tab-pane" id="tab_b">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <h3 class="panel-title">Paid Invoices</h3>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <table id="tblpaidinvoice" class="table table-bordered table-condensed table-hover table-responsive"></table>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tab-pane" id="tab_c">
                <div class="row">
                    <div class="col-lg-12">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="lblmodalheder"></h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="col-lg-6 col-md-6 col-sm-6">
                                <label id="invoicetext"></label>
                                <label id="lblinvoiceID"></label>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6">
                                <label>Mode :</label>
                                <label id="status"></label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="col-lg-6 col-md-6 col-sm-6">

                                <input class="form-control" type="text" placeholder="Enter Name" id="txtName" />


                                <input class="form-control" type="text" placeholder="Enter Email" id="txtEmail" />


                                <input class="form-control" type="text" placeholder="Enter Mobile" id="txtMobile" />
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6">

                                <input class="form-control" type="text" id="Invoicedate" placeholder="Enter  Date" disabled="disabled" />

                                <input class="form-control" type="text" placeholder="Enter GST" id="txtCGST" />


                                <textarea class="form-control" placeholder="Enter Address(or)Company's Name" id="txtAddress" style="height: 34px; resize: none"></textarea>
                            </div>
                        </div>
                    </div>
                    <hr />
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
                                    <input type="button" class="btn btn-primary" value="Update Invoice" style="width: 390px;" onclick="return UpdateInvoice();" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
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
                    <div class="tab-content col-md-10">
                        <ul class="nav nav-tabs ">
                            <li class="active"><a href="#tab_Cash" data-toggle="pill">Cash</a></li>
                            <li><a href="#tab_Cheque" data-toggle="pill">Cheque</a></li>
                            <li><a href="#tab_Neft" data-toggle="pill">NEFT/RTGS</a></li>
                            <li><a href="#tab_Paytm" data-toggle="pill">Paytm</a></li>
                            <li><a href="#tab_EZETAP" data-toggle="pill">EzeTap</a></li>

                        </ul>
                    </div>
                    <div class="tab-content col-md-12">
                        <div class="tab-pane active" id="tab_Cash">

                            <div class="row">
                                <fieldset>

                                    <!-- Form Name -->
                                    <br />
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Amount</label>
                                            <div class="col-md-4">
                                                <input id="txtCashAmount" name="fn" type="text" placeholder="Amount" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">

                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Cash Date</label>
                                            <div class="col-md-4">
                                                <input id="txtcashDate" name="fn" type="text" placeholder="Date" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Collcted by</label>
                                            <div class="col-md-4">
                                                <input id="txtCollectedBY" name="fn" type="text" placeholder="Collcted by" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-4 control-label" for="submit"></label>
                                        <div class="col-md-4">
                                            <button name="submit" class="btn btn-primary" onclick=" return CashPayment();">SUBMIT</button>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="tab-pane" id="tab_Cheque">
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
                                            <label class="col-md-2 control-label" for="fn">Date</label>
                                            <div class="col-md-4">
                                                <input id="txtCheQueDate" name="fn" type="text" placeholder="Date" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Chque No</label>
                                            <div class="col-md-4">
                                                <input id="txtChqueNo" name="fn" type="text" placeholder="Chque No" class="form-control input-md" />
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
                                    <div class="form-group">
                                        <label class="col-md-4 control-label" for="submit"></label>
                                        <div class="col-md-4">
                                            <button name="submit" class="btn btn-primary" onclick="return ChequePayment();">SUBMIT</button>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="tab-pane" id="tab_Neft">
                            <div class="row">
                                <fieldset>

                                    <!-- Form Name -->
                                    <br />
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Amount</label>
                                            <div class="col-md-4">
                                                <input id="txtNEFTAmount" name="fn" type="text" placeholder="Amount" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">

                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Date</label>
                                            <div class="col-md-4">
                                                <input id="txtNEFTDate" name="fn" type="text" placeholder="Date" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Transaction No</label>
                                            <div class="col-md-4">
                                                <input id="txtNEFTNo" name="fn" type="text" placeholder="Transaction No" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Bank Details</label>
                                            <div class="col-md-4">
                                                <input id="txtNEFTBankName" name="fn" type="text" placeholder="Bank Details" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-4 control-label" for="submit"></label>
                                        <div class="col-md-4">
                                            <button name="submit" class="btn btn-primary" onclick="return NeftPayment();">SUBMIT</button>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="tab-pane" id="tab_Paytm">
                            <div class="row">
                                <fieldset>

                                    <!-- Form Name -->
                                    <br />
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Amount</label>
                                            <div class="col-md-4">
                                                <input id="txtPaytmAmount" name="fn" type="text" placeholder="Amount" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">

                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Date</label>
                                            <div class="col-md-4">
                                                <input id="txtPaytmDate" name="fn" type="text" placeholder="Date" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Transaction No</label>
                                            <div class="col-md-4">
                                                <input id="txtPaytmNo" name="fn" type="text" placeholder="Transaction No" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">

                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Collected By</label>
                                            <div class="col-md-4">
                                                <input id="txtPaytmCollected" name="fn" type="text" placeholder="Collected By" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-4 control-label" for="submit"></label>
                                        <div class="col-md-4">
                                            <button name="submit" class="btn btn-primary" onclick="return PaytmPayment();">SUBMIT</button>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="tab-pane" id="tab_EZETAP">
                            <div class="row">
                                <fieldset>

                                    <!-- Form Name -->
                                    <br />
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Amount</label>
                                            <div class="col-md-4">
                                                <input id="txtEzetapAmount" name="fn" type="text" placeholder="Amount" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">

                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Date</label>
                                            <div class="col-md-4">
                                                <input id="txEzetapDate" name="fn" type="text" placeholder="Date" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Transaction No</label>
                                            <div class="col-md-4">
                                                <input id="txtEzetapNo" name="fn" type="text" placeholder="Transaction No" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">

                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="fn">Collected By</label>
                                            <div class="col-md-4">
                                                <input id="txtEzetapCollected" name="fn" type="text" placeholder="Collected By" class="form-control input-md" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-4 control-label" for="submit"></label>
                                        <div class="col-md-4">
                                            <button name="submit" class="btn btn-primary" onclick="return EzetapPayment();">SUBMIT</button>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
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
    <style type="text/css">
        .nav-tabs li a:focus,
        .panel-heading a:focus {
            outline: none;
        }

        .panel-heading a,
        .panel-heading a:hover,
        .panel-heading a:focus {
            text-decoration: none;
            color: #777777;
        }

        .btn-glyphicon {
            padding: 8px;
            background: #ffffff;
            margin-right: 4px;
        }

        .icon-btn {
            padding: 1px 15px 3px 2px;
            border-radius: 50px;
        }

        .nav-tabs > li > a {
            margin-right: 2px;
            line-height: 1.42857143;
            border: 1px solid transparent;
            border-radius: 4px 4px 0 0;
            border: 1px solid #dddddd;
            background-color: #ffffff;
        }

        .nav-tabs > li.active > a, .nav-tabs > li.active > a:hover, .nav-tabs > li.active > a:focus {
            color: white;
            cursor: default;
            background-color: #428bca;
            border: 1px solid #ddd;
            border-bottom-color: transparent;
        }
    </style>
    <script src="../Scripts/jquery-2.1.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var pickerOpts =
                {
                    // minDate: new Date(),
                    pickTime: false,
                    dateFormat: 'dd-M-yy',
                    showButtonPanel: true,
                    showAnim: ''
                };

            $("#Invoicedate,#txtcashDate,#txtCheQueDate,#txtNEFTDate,#txtPaytmDate,#txEzetapDate").datetimepicker(pickerOpts);
            EB_FetechproformaInvoices();

            $("#txtMobile,#txtQuantity,#txtAmount,#txtDiscount").keydown(numberOnly);
        });
        function EB_FetechproformaInvoices() {
            // var ApType = $(ID).attr('data-apptype');
            $("#modalsmall").modal("show");
            $.ajax({
                url: "DisplayInvoces.aspx/EB_FetechAllInvoices",
                type: "POST",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != 0) {
                        var dt = JSON.parse(data.d);
                        $('#tblinvoice').dataTable({
                            "bDestroy": true,
                            "bRetrieve": false,
                            "sPaginationType": "full_numbers",
                            "aaData": dt,
                            "bAutoWidth": true,
                            "bDeferRender": true,
                            "aoColumns":
                                [

                                    { "mData": "Name", 'sTitle': 'Name', "sClass": 'center', 'sWidth': '5%' },
                                    { "mData": "Email", 'sTitle': 'Email', "sClass": 'center', 'sWidth': '5%' },
                                    { "mData": "Mobile", 'sTitle': 'Mobile', "sClass": 'center', 'sWidth': '5%' },
                                    { "mData": "FinalAmount", 'sTitle': 'Amount', "sClass": 'center', 'sWidth': '3%' },
                                    {
                                        "mData": 'Status', 'sTitle': 'Invoice', 'bSearchable': false, "sClass": 'center', 'sWidth': '5%', 'bSortable': false, 'mRender': function (data, type, full) {
                                            if (full.Status == 1) {
                                                return 'Sent';
                                            }
                                            else if (full.Status == 5) {
                                                return "Paid";
                                            }
                                            else {
                                                return 'Cancelled';
                                            }

                                        }
                                    },
                                    { "mData": "StrPaymentStatus", 'sTitle': 'Receipt', "sClass": 'center', 'sWidth': '5%' },
                                    {
                                        "mData": null, 'sTitle': 'Date', "sClass": 'center', 'sWidth': '10%', 'mRender': function (data, type, full) {

                                            return '<lable>' + moment(full.InvoiceDate).format('L') + '</lable>';

                                        }
                                    },
                                    {
                                        "mData": 'InvoiceID', 'sTitle': 'EDIT', "sClass": 'center', 'sWidth': '5%', 'bSearchable': false, 'bSortable': false, 'mRender': function (data, type, full) {
                                            if (full.Status == 1) {
                                                return '<a  onclick="Loadinvoice(this);" >EDIT</a>';
                                            }
                                            else if (full.Status == 5) {
                                                return "";
                                            }
                                            else {
                                                return '<a  onclick="Loadinvoice(this);" >EDIT</a>';
                                            }
                                        }
                                    },
                                    {
                                        "mData": 'InvoiceID', 'sTitle': 'Update', "sClass": 'center', 'sWidth': '5%', 'bSearchable': false, 'bSortable': false, 'mRender': function (data, type, full) {
                                            return '<a  onclick="UpdateReceiptinvoice(this);" >Update</a>';
                                        }
                                    },
                                    {
                                        "mData": 'InvoiceID', 'sTitle': 'Delete', 'bSearchable': false, "sClass": 'center', 'sWidth': '5%', 'bSortable': false, 'mRender': function (data, type, full) {
                                            if (full.Status == 1) {
                                                return '<a  onclick="DeleteInvoiceByInvoiceID(this);" >Delete</a>';
                                            }
                                            else if (full.Status == 5) {
                                                return "";
                                            }
                                            else {
                                                return 'Cancelled';
                                            }

                                        }
                                    },
                                    {
                                        "mData": 'Status', 'sTitle': 'Resend', 'bSearchable': false, "sClass": 'center', 'sWidth': '5%', 'bSortable': false, 'mRender': function (data, type, full) {
                                            if (full.Status == 1) {
                                                return '<a  onclick="ResendInvoice(this);" >Invoice</a>';
                                            }
                                            else if (full.Status == 6) {
                                                return "";
                                            }
                                            else {
                                                return '<a  onclick="ResendReceiptInvoice(this);" >Receipt</a>';
                                            }
                                        }
                                    }
                                ]
                        });
                        $("#modalsmall").modal("hide");
                    }
                    else {
                        $("#UsersList").dataTable().fnClearTable();
                        $('#divUserslist').hide();
                    }
                },
                error: function (xhr, status, error) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
          function EB_FetechPaidInvoices() {
            // var ApType = $(ID).attr('data-apptype');
            $("#modalsmall").modal("show");
            $.ajax({
                url: "DisplayInvoces.aspx/EB_FetechpaidInvoices",
                type: "POST",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != 0) {
                        var dt = JSON.parse(data.d);
                        $('#tblpaidinvoice').dataTable({
                            "bDestroy": true,
                            "bRetrieve": false,
                            "sPaginationType": "full_numbers",
                            "aaData": dt,
                            "bAutoWidth": true,
                            "bDeferRender": true,
                            "aoColumns":
                                [

                                    { "mData": "Name", 'sTitle': 'Name', "sClass": 'center', 'sWidth': '5%' },
                                    { "mData": "Email", 'sTitle': 'Email', "sClass": 'center', 'sWidth': '5%' },
                                    { "mData": "Mobile", 'sTitle': 'Mobile', "sClass": 'center', 'sWidth': '5%' },
                                    { "mData": "FinalAmount", 'sTitle': 'Amount', "sClass": 'center', 'sWidth': '3%' },
                                    {
                                        "mData": 'Status', 'sTitle': 'Invoice', 'bSearchable': false, "sClass": 'center', 'sWidth': '5%', 'bSortable': false, 'mRender': function (data, type, full) {
                                            if (full.Status == 1) {
                                                return 'Sent';
                                            }
                                            else if (full.Status == 5) {
                                                return "Paid";
                                            }
                                            else {
                                                return 'Cancelled';
                                            }

                                        }
                                    },
                                    { "mData": "StrPaymentStatus", 'sTitle': 'Receipt', "sClass": 'center', 'sWidth': '5%' },
                                    {
                                        "mData": null, 'sTitle': 'Date', "sClass": 'center', 'sWidth': '10%', 'mRender': function (data, type, full) {
                                            return '<lable>' + moment(full.InvoiceDate).format('L') + '</lable>';

                                        }
                                    },
                                    //{
                                    //    "mData": 'InvoiceID', 'sTitle': 'EDIT', "sClass": 'center', 'sWidth': '5%', 'bSearchable': false, 'bSortable': false, 'mRender': function (data, type, full) {
                                    //        if (full.Status == 1) {
                                    //            return '<a  onclick="Loadinvoice(this);" >EDIT</a>';
                                    //        }
                                    //        else if (full.Status == 5) {
                                    //            return "";
                                    //        }
                                    //        else {
                                    //            return '<a  onclick="Loadinvoice(this);" >EDIT</a>';
                                    //        }
                                    //    }
                                    //},
                                    {
                                        "mData": 'InvoiceID', 'sTitle': 'Update', "sClass": 'center', 'sWidth': '5%', 'bSearchable': false, 'bSortable': false, 'mRender': function (data, type, full) {
                                            return '<a  onclick="UpdateReceiptinvoice1(this);" >Update</a>';
                                        }
                                    },
                                    //{
                                    //    "mData": 'InvoiceID', 'sTitle': 'Delete', 'bSearchable': false, "sClass": 'center', 'sWidth': '5%', 'bSortable': false, 'mRender': function (data, type, full) {
                                    //        if (full.Status == 1) {
                                    //            return '<a  onclick="DeleteInvoiceByInvoiceID(this);" >Delete</a>';
                                    //        }
                                    //        else if (full.Status == 5) {
                                    //            return "";
                                    //        }
                                    //        else {
                                    //            return 'Cancelled';
                                    //        }

                                    //    }
                                    //},
                                    {
                                        "mData": 'Status', 'sTitle': 'Resend', 'bSearchable': false, "sClass": 'center', 'sWidth': '5%', 'bSortable': false, 'mRender': function (data, type, full) {
                                            if (full.Status == 1) {
                                                return '<a  onclick="ResendInvoice(this);" >Invoice</a>';
                                            }
                                            else if (full.Status == 6) {
                                                return "";
                                            }
                                            else {
                                                return '<a  onclick="ResendReceiptInvoice(this);" >Receipt</a>';
                                            }
                                        }
                                    }
                                ]
                        });
                        $("#modalsmall").modal("hide");
                    }
                    else {
                        $("#UsersList").dataTable().fnClearTable();
                        $('#divUserslist').hide();
                    }
                },
                error: function (xhr, status, error) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        function OnblurCalculate() {
            //if (Invfor == 1) {
            //    OnblurCalculateEvent();
            //}
            //else {
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
        // }
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
        var invoiceType = 0;
        var Status = 0;
        var Invfor = 0;
        function Loadinvoice(ss) {
            clearvalues();
            var tr = $(ss).closest("tr");
            var obj = $('#tblinvoice').dataTable().fnGetData(tr);

            Status = obj.Status;
            if (Status == 1) {
                $("#lblmodalheder").text("Performa Invoice Details");
                $("#invoicetext").text("Proforma Invoice:#");
                $("#status").text("Not Made");
            }
            else {
                $("#lblmodalheder").text("Invoice Details");
                $("#invoicetext").text("Invoice:#");
                $("#status").text("Paid");
            }
            if (Status == 1 || Status == 5 || Status == 6) {
                $("#myModal").modal("show");
            }
            else {
                $("#myModal").modal("hide");
                return false;
            }
            invoiceType = obj.InvoiceType;
            $("#lblinvoiceID").text(obj.InvoiceID);

            $("#txtName").val(obj.Name);
            $("#txtEmail").val(obj.Email);
            $("#txtMobile").val(obj.Mobile);
            $("#txtAddress").val(obj.Address);
            $("#txtCGST").val(obj.ClientGST);
            $('#Invoicedate').val(moment(obj.InvoiceDate).format("l"));
            $("#txtInvoice").val("1");
            $("#txtQuantity").val(obj.Quantity);
            $("#txtdescription").val(obj.Description);
            $("#txtActualPrice").val(obj.ActualAmount);
            $("#txtAmount").val(obj.ActualAmount);
            $("#txtDiscount").val(obj.Discount);
            $("#lblDiscAmount").text(obj.DiscAmount);
            $('#txtTerms').val(obj.Terms);
            $("#lblBeforeTaxAmount").text(obj.BeforeTaxAmount);
            $("#lblCGST").text(obj.CGST);
            $("#lblSGST").text(obj.SGST);
            $("#lblFinalAmount").text(obj.FinalAmount);
            Invfor = obj.InvoiceFor;
        }

        function UpdateInvoice() {
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
            var txtTerms = $('#txtTerms').val();
            if (txtName === "") {
                $("#txtName").focus();
                return false;
            }
            if (txtEmail === "") {
                $("#txtEmail").focus();
                return false;
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
            data.InvoiceID = $("#lblinvoiceID").text();
            data.Name = txtName;
            data.Email = txtEmail;
            data.Mobile = txtMobile;
            data.Address = txtAddress;
            data.InvoiceDate = txtInvoiceDate;
            data.Invoice = txtInvoice;
            data.Quantity = txtQuantity;
            data.Description = txtdescription;
            data.ActualAmount = txtActualPrice;
            data.Discount = txtDiscount;
            data.DiscAmount = lblDiscAmount;
            data.TaxAmount = parseInt(lblCGST) + parseInt(lblSGST);
            data.BeforeTaxAmount = lblBeforeTaxAmount;
            data.CGST = lblCGST;
            data.SGST = lblSGST;
            data.IGST = lblIGST;
            data.FinalAmount = lblFinalAmount;
            data.Terms = txtTerms;
            data.ClientGST = txtClientGST;
            data.Status = Status;
            data.InvoiceType = invoiceType;
            data = JSON.stringify(data);
            var obj1 = {};
            obj1.obj = data;
            obj1 = JSON.stringify(obj1);
            $.ajax({
                url: "DisplayInvoces.aspx/UpdateInvoices",
                type: "POST",
                data: obj1,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    if (data.d != '0') {
                        swal("Success");
                    }
                },
                error: function (xhr, error, status) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        function clearvalues() {
            $("#txtInvoice").val('');
            $("#txtdescription").val('');
            $("#txtQuantity").val('');
            $("#txtAmount").val('');
            $("#txtActualPrice").val('');
            $("#txtDiscount").val('');
        }
        function ClearAmountValues() {
            $("#txtDiscount").val('');
            $("#lblDiscAmount").text('');
            $("#lblBeforeTaxAmount").text('');
            $("#lblCGST").text('');
            $("#lblSGST").text('');
            $("#lblFinalAmount").text('');
        }
        var RInvoiceType = 0;
        var RInvoiceID = 0;
        function UpdateReceiptinvoice(txt) {
            var tr = $(txt).closest("tr");
            var obj = $('#tblinvoice').dataTable().fnGetData(tr);
            RInvoiceType = obj.InvoiceType;
            RInvoiceID = obj.InvoiceID;
            $("#myReceptModal").modal("show");
        }
        function UpdateReceiptinvoice1(txt) {
            var tr = $(txt).closest("tr");
            var obj = $('#tblpaidinvoice').dataTable().fnGetData(tr);
            RInvoiceType = obj.InvoiceType;
            RInvoiceID = obj.InvoiceID;
            $("#myReceptModal").modal("show");
        }
        function CashPayment() {
            var txtCashAmount = $("#txtCashAmount").val();
            var txtCollectedBY = $("#txtCollectedBY").val();
            var txtcashDate = $("#txtcashDate").val();
            //txtcashDate = new Date(txtcashDate);

            if (txtCashAmount === "" || txtCashAmount == 0) {
                $("#txtCashAmount").focus();
                return false;
            }
            if (txtcashDate === "") {
                $("#txtcashDate").focus();
                return false;
            }
            var data = {};
            data.ChequeAmount = txtCashAmount;
            data.ChequeDate = txtcashDate;
            data.CollectedBy = txtCollectedBY;
            data.InvoiceID = RInvoiceID;
            data.InvoiceType = RInvoiceType;
            data = JSON.stringify(data);
            var obj1 = {};
            obj1.Obj = data;
            obj1 = JSON.stringify(obj1);
            $.ajax({
                url: "DisplayInvoces.aspx/CashPayment",
                type: "POST",
                data: obj1,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    if (data.d != '0') {
                        swal("Success");
                    }
                },
                error: function (xhr, error, status) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        function ChequePayment() {
            var txtChequeAmount = $("#txtChequeAmount").val();
            var txtCheQueDate = $("#txtCheQueDate").val();
            //  txtCheQueDate = new Date(txtCheQueDate);
            var txtChqueNo = $("#txtChqueNo").val();
            var txtBankName = $("#txtBankName").val();
            var txtChequeCollected = $("#txtChequeCollected").val();

            if (txtChequeAmount === "" || txtChequeAmount == 0) {
                $("#txtChequeAmount").focus();
                return false;
            }
            if (txtCheQueDate === "") {
                $("#txtCheQueDate").focus();
                return false;
            }
            if (txtChqueNo === "" || txtChqueNo == 0) {
                $("#txtChqueNo").focus();
                return false;
            }
            var data = {};
            data.ChequeAmount = txtChequeAmount;
            data.ChequeDate = txtCheQueDate;
            data.CollectedBy = txtChequeCollected;
            data.ChequeNo = txtChqueNo;
            data.BankDetails = txtBankName;
            data.InvoiceID = RInvoiceID;
            data.InvoiceType = RInvoiceType;
            data = JSON.stringify(data);
            var obj1 = {};
            obj1.Obj = data;
            obj1 = JSON.stringify(obj1);
            $.ajax({
                url: "DisplayInvoces.aspx/ChequePayment",
                type: "POST",
                data: obj1,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    if (data.d != '0') {
                        swal("Success");
                    }
                },
                error: function (xhr, error, status) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        function NeftPayment() {
            var txtNEFTAmount = $("#txtNEFTAmount").val();
            var txtNEFTDate = $("#txtNEFTDate").val();
            // txtNEFTDate = new Date(txtNEFTDate);
            var txtNEFTNo = $("#txtNEFTNo").val();
            var txtNEFTBankName = $("#txtNEFTBankName").val();
            if (txtNEFTAmount === "" || txtNEFTAmount == 0) {
                $("#txtNEFTAmount").focus();
                return false;
            }
            if (txtNEFTDate === "") {
                $("#txtNEFTDate").focus();
                return false;
            }
            if (txtNEFTNo === "" || txtNEFTNo == 0) {
                $("#txtNEFTNo").focus();
                return false;
            }
            var data = {};
            data.ChequeAmount = txtNEFTAmount;
            data.ChequeDate = txtNEFTDate;
            data.ChequeNo = txtNEFTNo;
            data.BankDetails = txtNEFTBankName;
            data.InvoiceID = RInvoiceID;
            data.InvoiceType = RInvoiceType;
            data = JSON.stringify(data);
            var obj1 = {};
            obj1.Obj = data;
            obj1 = JSON.stringify(obj1);
            $.ajax({
                url: "DisplayInvoces.aspx/NeftPayment",
                type: "POST",
                data: obj1,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    if (data.d != '0') {
                        swal("Success");
                    }
                },
                error: function (xhr, error, status) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        function PaytmPayment() {
            var txtPaytmAmount = $("#txtPaytmAmount").val();
            var txtPaytmDate = $("#txtPaytmDate").val();
            // txtPaytmDate = new Date(txtPaytmDate);
            var txtPaytmNo = $("#txtPaytmNo").val();
            var txtPaytmCollected = $("#txtPaytmCollected").val();

            if (txtPaytmAmount === "" || txtPaytmAmount == 0) {
                $("#txtPaytmAmount").focus();
                return false;
            }
            if (txtPaytmDate === "") {
                $("#txtPaytmDate").focus();
                return false;
            }
            if (txtPaytmNo === "" || txtPaytmNo == 0) {
                $("#txtPaytmNo").focus();
                return false;
            }
            var data = {};
            data.ChequeAmount = txtPaytmAmount;
            data.ChequeDate = txtPaytmDate;
            data.CollectedBy = txtPaytmCollected;
            data.ChequeNo = txtPaytmNo;
            data.InvoiceID = RInvoiceID;
            data.InvoiceType = RInvoiceType;
            data = JSON.stringify(data);
            var obj1 = {};
            obj1.Obj = data;
            obj1 = JSON.stringify(obj1);
            $.ajax({
                url: "DisplayInvoces.aspx/PaytmPayment",
                type: "POST",
                data: obj1,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    if (data.d != '0') {
                        swal("Success");
                    }
                },
                error: function (xhr, error, status) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        function EzetapPayment() {
            var txtEzetapAmount = $("#txtEzetapAmount").val();
            var txEzetapDate = $("#txEzetapDate").val();
            // txEzetapDate = new Date(txEzetapDate);
            var txtEzetapNo = $("#txtEzetapNo").val();
            var txtEzetapCollected = $("#txtEzetapCollected").val();

            if (txtEzetapAmount === "" || txtEzetapAmount == 0) {
                $("#txtEzetapAmount").focus();
                return false;
            }
            if (txEzetapDate === "") {
                $("#txtCheQueDate").focus();
                return false;
            }
            if (txtEzetapNo === "" || txtEzetapNo == 0) {
                $("#txtChqueNo").focus();
                return false;
            }
            var data = {};
            data.ChequeAmount = txtEzetapAmount;
            data.ChequeDate = txEzetapDate;
            data.CollectedBy = txtEzetapCollected;
            data.ChequeNo = txtEzetapNo;
            data.InvoiceID = RInvoiceID;
            data.InvoiceType = RInvoiceType;
            data = JSON.stringify(data);
            var obj1 = {};
            obj1.Obj = data;
            obj1 = JSON.stringify(obj1);
            $.ajax({
                url: "DisplayInvoces.aspx/EzetapPayment",
                type: "POST",
                data: obj1,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    if (data.d != '0') {
                        swal("Success");
                    }
                },
                error: function (xhr, error, status) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        function DeleteInvoiceByInvoiceID(ss) {
            var tr = $(ss).closest("tr");
            var obj = $('#tblinvoice').dataTable().fnGetData(tr);
            var DInvoiceType = obj.InvoiceType;
            var DInvoiceID = obj.InvoiceID;
            $.ajax({
                url: "DisplayInvoces.aspx/DeleteInvoiceByInvoiceID",
                type: "POST",
                data: "{'InvoiceId':'" + DInvoiceID + "','InvoiceType':'" + DInvoiceType + "'}",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    if (data.d != '0') {
                        swal("Success");
                    }
                },
                error: function (xhr, error, status) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        function ResendInvoice(ss) {
            var tr = $(ss).closest("tr");
            var obj = $('#tblinvoice').dataTable().fnGetData(tr);
            var DInvoiceType = obj.InvoiceType;
            var DInvoiceID = obj.InvoiceID;
            $.ajax({
                url: "DisplayInvoces.aspx/ResendInvoice",
                type: "POST",
                data: "{'InvoiceId':'" + DInvoiceID + "','InvoiceType':'" + DInvoiceType + "'}",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    if (data.d != '0') {
                        swal("Success");
                    }
                },
                error: function (xhr, error, status) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        function ResendReceiptInvoice(ss) {
            var tr = $(ss).closest("tr");
            var obj = $('#tblinvoice').dataTable().fnGetData(tr);
            var DInvoiceType = obj.InvoiceType;
            var DInvoiceID = obj.InvoiceID;
            $.ajax({
                url: "DisplayInvoces.aspx/ResendReceiptInvoice",
                type: "POST",
                data: "{'InvoiceId':'" + DInvoiceID + "','InvoiceType':'" + DInvoiceType + "'}",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    if (data.d != '0') {
                        swal("Success");
                    }
                },
                error: function (xhr, error, status) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        function OnblurCalculateEvent() {
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
                amt = Math.round(amt);
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
                    // var tTax = (BeforeTax / 100) * 18.00;
                    var tTax = 0;
                    tTax = Math.round(tTax);
                    var GST = tTax / 2;
                    GST = Math.round(GST);
                    $("#lblCGST").text(GST);
                    $("#lblSGST").text(GST);
                    var FinalAmount = BeforeTax + tTax;
                    //FinalAmount = Math.round(FinalAmount);
                    $("#lblFinalAmount").text(FinalAmount);
                }
                else {
                    $("#lblBeforeTaxAmount").text(amt);
                    //   var tTax = (amt / 100) * 18.00;
                    var tTax = 0;
                    tTax = Math.round(tTax);
                    var GST = tTax / 2;
                    GST = Math.round(GST);
                    $("#lblCGST").text(GST);
                    $("#lblSGST").text(GST);
                    var FinalAmount = amt + tTax;
                    // FinalAmount = Math.round(FinalAmount);
                    $("#lblFinalAmount").text(FinalAmount);
                }

            }
        }
    </script>
</asp:Content>
