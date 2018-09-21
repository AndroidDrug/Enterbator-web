<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CountryAdmin.Master" AutoEventWireup="true" CodeBehind="InviteOwner.aspx.cs" Inherits="Entrebator.CountryAdmin.InviteOwner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Countryadmin" runat="server">

     <div class="panel panel-success" id="IdPersonal">
        <div class="panel-heading">
            <h3 class="panel-title">Invite the business owner's
                <button type="button" class="btn btn-success btn-xs InvHis" onclick="return OpenInviteHelpHistory();">Invitation History</button>
                <button type="button" class="btn btn-success btn-xs InvHis" onclick="return OpenMultipleInvite();" style="margin-right: 10px">Multiple Invite</button>
            </h3>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" id="invtownr">
                <div class="row">
                    <div class="col-lg-8">
                        <div class="col-lg-2">
                            <label>Name </label>
                        </div>
                        <div class="col-lg-6">
                            <input type="text" class="form-control" id="txtname" placeholder="Enter Name" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-8">
                        <div class="col-lg-2">
                            <label>Email </label>
                        </div>
                        <div class="col-lg-6">
                            <input type="text" class="form-control" id="txtemail" onblur="return CheckEmail(this);" placeholder="Enter Email" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-8">
                        <div class="col-lg-2">
                            <label>Mobile </label>
                        </div>
                        <div class="col-lg-6">
                            <input type="text" class="form-control" id="txtmobile" onblur="return CheckMobile(this);" placeholder="Enter Mobile" maxlength="10" />
                        </div>
                    </div>
                </div>
                <br />
            </div>
            <div class="row">
                <div class="col-lg-8">
                    <div class="col-lg-4">
                        <button type="button" class="btn btn-success" id="intown" onclick="InviteOwner();" style="float: right;">Invite</button>
                    </div>
                    <div class="col-lg-2">
                        <button type="button" class="btn btn-success" id="clearownr" onclick="ClearOwner();" style="float: right;">Clear</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" id="modalsmall" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog" style="padding-top: 250px; padding-left: 250px;">
            <div class="form-group">
                <img src="../Documents/Common/3.GIF" />
            </div>
        </div>
    </div>


    <script src="../Scripts/jquery-2.1.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function ()
        {
            $("#txtmobile").keydown(numberOnly);
        });
        //Function to check email already register or not
        function CheckEmail(useml)
        {
            var uemail = $(useml).val();
            uemail = $.trim(uemail);
            $.ajax({
                url: "InviteOwner.aspx/CheckEmail",
                type: "Post",
                data: "{'emlVal':'" + uemail + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data)
                {
                    var d = parseInt(data.d);
                    if (d != 0)
                    {
                        $('#txtemail').val('');
                        sweetAlert('Email already registered with entrebator!');
                        return false;
                    }
                },
                error: function (xhr, status, error)
                {
                    sweetAlert('Something went wrong, please try after sometime!');
                }
            });
        }
        //Function to check mobile already register or not
        function CheckMobile(mob)
        {
            var mobile = $(mob).val();
            mobile = $.trim(mobile);
            $.ajax({
                url: "InviteOwner.aspx/CheckMobile",
                type: "Post",
                data: "{'mobile':'" + mobile + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data)
                {
                    var d = parseInt(data.d);
                    if (d != 0)
                    {
                        $('#txtmobile').val('');
                        sweetAlert('Mobile already registered with entrebator!');
                        return false;
                    }
                },
                error: function (xhr, status, error)
                {
                    sweetAlert('Something went wrong, please try after sometime!');
                }
            }).responseText;
        }

        function InviteOwner()
        {
            var txtFname = $('#txtname').val();
            var txtMobile = $('#txtmobile').val();
            var txtEmail = $('#txtemail').val();
            var txtMessage = $('#txtmessage').val();
            var mob = txtMobile;
            CheckMobile(mob);

            var dt = new Date();
            dt = dt.toUTCString(dt);

            if (txtFname === '')
            {
                $('#txtname').parent('div').addClass('has-error');
                return false;
            }
            else
            {
                $('#txtname').parent('div').removeClass('has-error');
            }
            if (txtEmail === '')
            {
                $('#txtemail').parent('div').addClass('has-error');
                return false;
            }
            else if (!validateEmail(txtEmail))
            {
                $('#txtemail').parent('div').addClass('has-error');
                sweetAlert('Enter valid email');
                return false;
            }
            else
            {
                $('#txtemail').parent('div').removeClass('has-error');
            }
            var obj = {};
            obj.strName = txtFname;
            obj.strMobile = txtMobile;
            obj.strEmail = txtEmail;
            obj.strInvitationMessage = txtMessage;
            obj.dateInvitationDate = dt;

            obj = JSON.stringify(obj);
            $('#modalsmall').modal('show');
            $.ajax({
                url: "InviteOwner.aspx/InviteBOwner",
                type: "POST",
                data: "{'obj':'" + obj + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data)
                {
                    ClearOwner();
                    $('#modalsmall').modal('hide');
                    sweetAlert("Great!", "You Have Invited Sucessfully", "success");
                },
                error: function (xhr, status, error)
                {
                    $('#modalsmall').modal('hide');
                    sweetAlert('Something went wrong, please try after sometime!');
                }
            });
        }

        function ClearOwner()
        {
            $('#txtname').val('');
            $('#txtemail').val('');
            $('#txtmobile').val('');
            $('#txtmessage').val('');
        }

        function OpenMultipleInvite()
        {
            window.open("BulkInvite.aspx");
        }

        function OpenInviteHelpHistory()
        {
            window.open("InviteHistory.aspx");
        }

        //Function for retrict alphabetics
        function numberOnly(e)
        {
            // Allow: backspace, delete, tab, escape, enter and .
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                // Allow: Ctrl+A
                (e.keyCode == 65 && e.ctrlKey === true) ||
                // Allow: home, end, left, right
                (e.keyCode >= 35 && e.keyCode <= 39))
            {
                // let it happen, don't do anything
                return;
            }
            // Ensure that it is a number and stop the keypress
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            {
                e.preventDefault();
            }
        }
        //function for validate emailid
        function validateEmail(txtEmail)
        {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(txtEmail);
        }
    </script>

</asp:Content>
