<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Associative.Master" AutoEventWireup="true" CodeBehind="AssocitiveProfile.aspx.cs" Inherits="Entrebator.Associative.AssocitiveProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Associatmstr" runat="server">
    <div class="well">
        <div class="row">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-lg-3">
                        <img id="myprofileimage" src="ProfileHydrangeas" style="border-radius: 80%; height: 120px; width: 120px;" onerror="this.onload = null; this.src='../Documents/Common/profile%20default.jpg';" />
                    </div>
                    <div class="col-lg-4">
                        <div class="row">
                            <div class="col-lg-12">
                                <label>FirstName :&nbsp</label>
                                <span id="lblfname"></span>
                                <div class="form-group">
                                    <input class="form-control" maxlength="50" style="display: none;" type="text" id="txtfname" placeholder="First Name" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <label>Email :&nbsp </label>
                                <span id="lblemail"></span>
                                <div class="form-group">
                                    <input class="form-control" style="display: none;" type="text" autofocus="autofocus" id="txtemail" readonly="readonly" placeholder="Email" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <button id="btnPPEdit" type="button" class="btn btn-primary" onclick="return EditProfile(this);">Edit</button>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <button style="display: none" id="btnPPCancel" type="button" class="btn btn-primary" onclick="return CancelProfile(this);">Cancel</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5">
                        <div class="row">
                            <div class="col-lg-8">
                                <label>LastName : &nbsp</label><span id="lbllname"></span>
                                <div class="form-group">
                                    <input class="form-control" style="display: none;" type="text" autofocus="autofocus" id="txtlname" placeholder="Last Name" />
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <input type="button" id="pswd" class="btn btn-success btn-xs" value="Change Password" onclick="OpenPassModel();" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <label>Phone :&nbsp </label>
                                <span id="lblphone"></span>
                                <div class="form-group">
                                    <div class="form-group">
                                        <input class="form-control" style="display: none;" type="text" autofocus="autofocus" id="txtphone" placeholder="Phone" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="form-group" id="helppropic" style="display: none">
                                    <input type="file" class="btn-primary" title="Select profile photo" id="fupProfileImage" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" id="modalchangePass" style="display: none" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" style="color: #000!important;"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="frgpass"><span>Change Password</span></h4>
                </div>
                <div class="modal-body">
                    <div id="divpasswrd">
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-12">
                                    <label style="height: 40px;">Your email:</label><label id="usreml" style="margin-left: 10px;"></label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <label>Enter Current Password</label><br />
                                    <input type="password" class="form-control" id="txtcurpass" /><br />
                                    <label>Enter New Password</label><br />
                                    <input type="password" class="form-control" id="txtnewpass" maxlength="25" /><br />
                                    <label>Re-enter New Password</label><br />
                                    <input type="password" class="form-control" id="txtretyppass" maxlength="25" /><br />
                                </div>
                            </div>
                            <div id="alertmsg" style="display: none;">
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" id="btnsave" class="btn btn-success" onclick="ChangePassword();">Change</button>
                    <button type="button" id="btnCancel" class="btn btn-default" onclick="closepop();">Close</button>
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
        var JUserID = '<%= Session["UserID"]%>';
        var intCityID = null;
        var intStateID = null;
        var intCountryID = null;
        var memphoto = null;

        $(document).ready(function () {
            Loadprofile();
            //  LoadCountry();
        });

        function Loadprofile() {
            $('#modalsmall').modal('show');
            $.ajax({
                url: "AssocitiveProfile.aspx/loadProfileDetails",
                type: "POST",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    var data = JSON.parse(data.d);
                    if (data.d != '') {
                        $('#btnPPCancel').hide();
                        $('#lblfname').text(data.strFirstName);
                        $('#lbllname').text(data.strLastName);
                        $('#lblemail').text(data.strEmail);
                        $('#lblphone').text(data.strMobile);
                        memphoto = data.strPhoto;
                        var ph = '../Documents/ProfilePhoto/' + memphoto;
                        $('#myprofileimage').attr('src', ph);
                        $('#lblCountry').text(data.strCountry);
                        intCountryID = data.intCountryID;
                        $('#usreml').text(data.strEmail);
                    }
                    $('#modalsmall').modal('hide');
                },
                error: function (xhr, status, error) {
                    $('#modalsmall').modal('hide');
                    sweetAlert('Something went wrong, please try after sometime!');
                }
            });

        }
        function EditProfile(btn) {
            var btnName = $(btn).text();
            if (btnName === 'Edit') {
                $('#btnPPEdit').text('Update');
                $('#btnPPCancel').show();
                $('#txtfname').show();
                $('#txtlname').show();
                $('#txtemail').show();
                $('#txtphone').show();
                $('#ddlCountry').show();
                $('#helppropic').show();
                $('#txtfname').val($('#lblfname').text());
                $('#txtlname').val($('#lbllname').text());
                $('#txtemail').val($('#lblemail').text());
                $('#txtphone').val($('#lblphone').text());
                $('#lblfname').hide();
                $('#lbllname').hide();
                $('#lblemail').hide();
                $('#lblphone').hide();

            }
            else if (btnName === 'Update') {
                var fname = $('#txtfname').val();
                var lname = $('#txtlname').val();
                var email = $('#txtemail').val();
                var phone = $('#txtphone').val();
                var ddlCountry = $('#ddlCountry').val();

                var fupProfileImage = $('#fupProfileImage').val();
                var strPhotoTemp = $('#fupProfileImage').val();
                var strPhotoExisting = $('#profileimage').attr('name');

                if (fname === '') {
                    $('#txtfname').parent('div').addClass('has-error');
                }
                else {
                    $('#txtfname').parent('div').removeClass('has-error');
                }
                if (lname === '') {
                    $('#txtlname').parent('div').addClass('has-error');
                }
                else {
                    $('#txtlname').parent('div').removeClass('has-error');
                }
                if (email === '') {
                    $('#txtemail').parent('div').addClass('has-error');
                }
                else {
                    $('#txtemail').parent('div').removeClass('has-error');
                }
                if (phone === '') {
                    $('#txtphone').parent('div').addClass('has-error');
                }
                else {
                    $('#txtphone').parent('div').removeClass('has-error');
                }
                var userData = {};
                userData.guidMemberID = JUserID;
                userData.strFirstName = fname;
                userData.strLastName = lname;
                userData.strEmail = email;
                userData.strMobile = phone;
                userData.intCountryID = ddlCountry;

                var file1 = $('#fupProfileImage').get(0);
                file1 = file1.files;
                var data = new FormData();
                if (fupProfileImage != '') {
                    data.append(file1[0].name, file1[0]);
                    userData.strPhoto = strPhotoTemp;
                }
                else {
                    userData.strPhoto = memphoto;
                }
                userData = JSON.stringify(userData);
                data.append("userdata", userData);
                var options = {};
                options.url = "AssocProfileUpdate.ashx";
                options.type = "post"
                options.data = data;
                options.contentType = false;
                options.async = false;
                options.processData = false;
                options.dataType = "application/json; charset=utf-8";
                var handlerRet = $.ajax(options);
                location.reload();
            }
        }

        function CancelProfile() {
            $('#btnPPCancel').hide();
            $('#btnPPEdit').text('Edit');
            $('#txtfname').hide();
            $('#txtlname').hide();
            $('#txtemail').hide();
            $('#txtphone').hide();
            $('#helppropic').hide();
            $('#lblfname').show();
            $('#lbllname').show();
            $('#lblemail').show();
            $('#lblphone').show();
        }

        function OpenPassModel() {
            $('#modalchangePass').modal('show');
        }

        function closepop() {
            $('#modalchangePass').modal('hide');
        }

        function ChangePassword() {
            var crps = $('#txtcurpass').val();
            var newpass = $('#txtnewpass').val();
            var repas = $('#txtretyppass').val();
            if (crps === '') {
                $("#btnsave").prop("disabled", true);
                var t = '<div class="alert alert-danger" role="alert" id="Errmsg">'
             + '<strong>Error!</strong> Please enter your old password !<span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> <span class="sr-only">Error:</span></div>';
                $('#alertmsg').after(t);
                $("#Errmsg").fadeTo(2000, 500).slideUp(1000, function () {
                    $("#Errmsg").remove();
                    $("#btnsave").prop("disabled", false);
                });
                return false;
            }
            if (newpass === '') {
                $("#btnsave").prop("disabled", true);
                var t = '<div class="alert alert-danger" role="alert" id="Errmsg">'
              + '<strong>Error!</strong> Please enter a new password !<span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> <span class="sr-only">Error:</span></div>';
                $('#alertmsg').after(t);
                $("#Errmsg").fadeTo(2000, 500).slideUp(1000, function () {
                    $("#Errmsg").remove();
                    $("#btnsave").prop("disabled", false);
                });
                return false;
            }
            if (repas === '') {
                $("#btnsave").prop("disabled", true);
                var t = '<div class="alert alert-danger" role="alert" id="Errmsg">'
             + '<strong>Error!</strong> Please re-type your new password !<span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> <span class="sr-only">Error:</span></div>';
                $('#alertmsg').after(t);
                $("#Errmsg").fadeTo(2000, 500).slideUp(1000, function () {
                    $("#Errmsg").remove();
                    $("#btnsave").prop("disabled", false);
                });
                return false;
            }
            if (newpass != repas) {
                $("#btnsave").prop("disabled", true);
                var t = '<div class="alert alert-danger" role="alert" id="Errmsg">'
               + '<strong>Error!</strong> Password Mismatch !<span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> <span class="sr-only">Error:</span></div>';
                $('#alertmsg').after(t);
                $("#Errmsg").fadeTo(2000, 500).slideUp(1000, function () {
                    $("#Errmsg").remove();
                    $("#btnsave").prop("disabled", false);
                });
                ClearPassWordFields();
                return false;
            }

            var dt = new Date();
            dt = dt.toUTCString(dt);

            var data = {};
            data.strOldPassword = crps;
            data.strNewPassword = repas;
            data.dtModifiedDate = dt;
            data = JSON.stringify(data);
            $.ajax({
                url: "../Profile/Profile.aspx/ChangePassword",
                type: "POST",
                data: "{'data':'" + data + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == 0) {
                        ClearPassWordFields();
                        $("#btnsave").prop("disabled", true);
                        var t = '<div class="alert alert-danger" role="alert" id="Errmsg">'
                + '<strong>Error!</strong> Current Password is Wrong !<span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> <span class="sr-only">Error:</span></div>';
                        $('#alertmsg').after(t);
                        $("#Errmsg").fadeTo(2000, 500).slideUp(1000, function () {
                            $("#Errmsg").remove();
                            $("#btnsave").prop("disabled", false);
                        });
                    }
                    else {
                        ClearPassWordFields();
                        sweetAlert("Password Changed Successfully..!");
                        $('#modalchangePass').modal('hide');
                    }
                },
                error: function (xhr, status, error) {
                    sweetAlert('Something went wrong, please try after sometime!');
                }
            });

        }

        function ClearPassWordFields() {
            $('#txtcurpass').val('');
            $('#txtnewpass').val('');
            $('#txtretyppass').val('');
        }
    </script>
</asp:Content>