<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport" />
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />

    <!-- ================== BEGIN BASE CSS STYLE ================== -->
    <link href="assets/css/app.min.css" rel="stylesheet" />
    <!-- ================== END BASE CSS STYLE ================== -->

    <link rel="icon" type="image/png" href="assets/img/loginLogo.png">

    <!-- ================== BEGIN BASE JS ================== -->
    <script src="assets/js/app.min.js"></script>
    <!-- ================== END BASE JS ================== -->

    <!-- ================== BEGIN PAGE LEVEL JS ================== -->
    <%--<script src="assets/js/demo/dashboard.demo.js"></script>--%>
    <!-- ================== END PAGE LEVEL JS ================== -->

    <!-- ================== BEGIN PAGE LEVEL JS ================== -->
    <script src="assets/plugins/twitter-bootstrap-wizard/jquery.bootstrap.wizard.min.js"></script>
    <script src="assets/js/demo/form-wizards.demo.js"></script>
    <!-- ================== END PAGE LEVEL JS ================== -->


    <script type="text/javascript">
        $(document).ready(function () {
            $('#show_password').hover(function show() {
                //Change the attribute to text  
                $('#txtPassword').attr('type', 'text');
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            },
                function () {
                    //Change the attribute back to password  
                    $('#txtPassword').attr('type', 'password');
                    $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
                });
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {
                $('#txtPas').attr('type', $(this).is(':checked') ? 'text' : 'password');
            });
        });
    </script>


    <script type="text/javascript">
        function ShowPopup(title, body, path) {
            $("#inverse-modal .modal-title").html(title);
            $("#inverse-modal .modal-body").html(body);
            document.getElementById("Go").href = path;
            $("#inverse-modal").modal("show");
        }

        function ShowPopupFailed(title, body) {
            $("#default-modal .modal-title").html(title);
            $("#default-modal .modal-body").html(body);
            $("#default-modal").modal("show");
        }

        function ShowPopupFull(title, body, path) {
            $("#full-cover-inverse-modal .modal-title").html(title);
            $("#full-cover-inverse-modal .modal-body").html(body);
            $("#full-cover-inverse-modal").modal("show");
        }

        function ShowPopupFullHide(title, body) {
            $("#full-cover-inverse-modal").modal("hidden");
        }

        function ShowPopupLarge(title, body) {
            $("#large-modal .modal-title").html(title);
            $("#large-modal .modal-body").html(body);
            $("#large-modal").modal("show");
        }



    </script>



   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-12">
        <!-- BEGIN card -->
        <div class="card m-b-15">

            <!-- END card-header -->
            <!-- BEGIN card-body -->
            <div class="card-body">
                <div class="form-group row m-b-0">
                    <div class="col-xl-3">
                        <h4>İşlemler</h4>
                        <hr />
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label>Saat <span class="text-danger">*</span></label>
                                <asp:Label ID="lblHour" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="input-group-append">
                                <span>
                                    <asp:TextBox ID="txtHour" runat="server" class="form-control" TextMode="Number" onKeyDown="if(this.value.length==11 && event.keyCode!=8 && event.keyCode!=9) return false;"></asp:TextBox>
                                </span>

                                <span>
                                    <asp:Button ID="btnIncreaseHour" runat="server" Text="increase_time" class="btn btn-primary m-b-5 m-r-3" OnClick="btnIncreaseHour_Click" />
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3" style="padding-left:20px;padding-right:20px">
                        <h4>create_product</h4>
                        <hr />
                        <div class="form-group">
                            <div class="form-group row m-b-0">
                                <label>Code <span class="text-danger">*</span></label>
                               
                                    <asp:TextBox ID="txtProductCode" runat="server" Width="30%" class="form-control"></asp:TextBox>
                               
                               <div class="col-sm-6">
                                    <asp:Button ID="btnGetProduct" runat="server" Text="get_product_info" class="btn btn-primary m-b-5 m-r-3" OnClick="btnGetProduct_Click" />
                                </div>
                            </div>

                          <div class="form-group row m-b-0">
                                <label>Price <span class="text-danger">*</span></label>

                                <asp:TextBox ID="txtPrice" runat="server" class="form-control"></asp:TextBox>

                            </div>

                           <div class="form-group row m-b-0">
                                <label>Stock <span class="text-danger">*</span></label>
                               
                                    <asp:TextBox ID="txtStock" runat="server" Width="30%"  class="form-control"></asp:TextBox>
                               
                                <div class="col-sm-6">
                                    <asp:Button ID="btncreate_product" runat="server" Text="create_product" class="btn btn-primary m-b-5 m-r-3" OnClick="btncreate_product_Click" />
                                  </div>
                            </div>

                          <div class="form-group row m-b-0">
                                <label>Result <span class="text-danger">*</span></label>

                                <asp:Label ID="lblProductResult" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3" style="padding-left:20px;padding-right:20px">
                        <h4>create_campaign</h4>
                        <hr />
                        <div class="form-group">
                            <div class="form-group row m-b-0">
                                <label>Name <span class="text-danger">*</span></label>
                               
                                    <asp:TextBox ID="txtCampaignName" runat="server" Width="30%" class="form-control"></asp:TextBox>
                               
                               <div class="col-sm-6">
                                    <asp:Button ID="btnget_campaign_info" runat="server" Text="get_campaign_info" class="btn btn-primary m-b-5 m-r-3" OnClick="btnget_campaign_info_Click" />
                                </div>
                            </div>

                          <div class="form-group row m-b-0">
                                <label>Product <span class="text-danger">*</span></label>

                                <asp:TextBox ID="txtCampaignProduct" runat="server" class="form-control"></asp:TextBox>

                            </div>
                             <div class="form-group row m-b-0">
                                <label>Duration <span class="text-danger">*</span></label>

                                <asp:TextBox ID="txtCampaignDuration" runat="server" class="form-control"></asp:TextBox>

                            </div>
                             <div class="form-group row m-b-0">
                                <label>Limit <span class="text-danger">*</span></label>

                                <asp:TextBox ID="txtCampaignLimit" runat="server" class="form-control"></asp:TextBox>

                            </div>

                           <div class="form-group row m-b-0">
                                <label>Target Sales Count <span class="text-danger">*</span></label>
                               
                                    <asp:TextBox ID="txtCampaignTargetSalesCount" runat="server" Width="30%"  class="form-control"></asp:TextBox>
                               
                                <div class="col-sm-3">
                                    <asp:Button ID="btnCampaignCreate" runat="server" Text="create_campaign" class="btn btn-primary m-b-5 m-r-3" OnClick="btnCampaignCreate_Click" />
                                  </div>
                            </div>

                          <div class="form-group row m-b-0">
                                <label>Result <span class="text-danger">*</span></label>

                                <asp:Label ID="lblCampaignResult" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
               

                 <div class="col-xl-3" style="padding-left:20px;padding-right:20px">
                        <h4>create_order</h4>
                        <hr />
                        <div class="form-group">
                            <div class="form-group row m-b-0">
                                <label>Product <span class="text-danger">*</span></label>
                               
                                    <asp:TextBox ID="txtOrderProduct" runat="server" Width="30%" class="form-control"></asp:TextBox>
                               
                           
                            </div>

                          <div class="form-group row m-b-0">
                                <label>Quantity <span class="text-danger">*</span></label>

                                <asp:TextBox ID="txtOrderQuantity" runat="server" class="form-control"></asp:TextBox>
                              <div class="col-sm-3">
                                    <asp:Button ID="btnOrderCreate" runat="server" Text="create_order" class="btn btn-primary m-b-5 m-r-3" OnClick="btnOrderCreate_Click" />
                                  </div>
                            </div>
                             

                         

                          <div class="form-group row m-b-0">
                                <label>Result <span class="text-danger">*</span></label>

                                <asp:Label ID="lblOrderResult" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

           


            </div>
            <!-- END card-body -->
        </div>
    </div>

    <!-- BEGIN modal -->
    <div class="modal fade" id="default-modal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Modal title</h4>
                    <button type="button" class="close" data-dismiss="modal"><span>&times;</span></button>
                </div>
                <div class="modal-body">
                    <p>One fine body&hellip;</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Tekrar Deney!</button>
                    <%-- <a id="GoBack" class="btn btn-red" >Tekrar Deney!</a>--%>
                </div>
            </div>
        </div>
    </div>
    <!-- END modal -->
    <!-- BEGIN modal -->
    <div class="modal modal-cover modal-inverse fade" id="full-cover-inverse-modal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header p-b-xs">
                    <h3 class="modal-title text-pink">Sign Up!</h3>

                </div>
                <div class="modal-body">
                    <p class="m-b-lg">
                        İşlemler Devam Ediyor. Lütfen bekleyiniz.<br />
                        Otomatik olarak yönlendirileceksiniz...

                    </p>

                    <div class="text-right p-t-10">
                    </div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
    <!-- END modal -->
    <!-- BEGIN modal -->
    <div class="modal modal-inverse fade" id="inverse-modal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"></h4>
                    <button type="button" class="close" data-dismiss="modal"><span>&times;</span></button>
                </div>

                <%-- <i class="fas fa-exclamation-triangle"></i>
                                       <i class="fa fa-exclamation-circle"></i>--%>
                <div class="modal-body">
                    <div class="error-page-icon"><i class="fa fa-exclamation-circle"></i></div>
                </div>
                <div class="modal-footer">
                    <a id="Go" class="btn btn-success">Sonuçları Görüntüle</a>
                </div>
            </div>
        </div>
    </div>
    <!-- END modal -->

    <!-- BEGIN modal -->
    <div class="modal fade" id="large-modal">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Large Modal title</h4>
                    <button type="button" class="close" data-dismiss="modal"><span>&times;</span></button>
                </div>
                <div class="modal-body">
                    <p>One fine body&hellip;</p>
                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-default" data-dismiss="modal">Tamam</button>--%>
                    <a class="btn btn-default" href=".">Tamam</a>

                </div>
            </div>
        </div>
    </div>
    <!-- END modal -->



    <!-- BEGIN breadcrumb -->

    <!-- END breadcrumb -->
    <!-- BEGIN page-header -->
    <h1 class="page-header">İşlem Listesi
			</h1>
    <!-- END page-header -->
    <!-- BEGIN card -->
    <div class="card ">

        <div class="card-body">
            <!-- BEGIN table -->

            <table id="datatables-default" class="table table-striped table-td-valign-middle table-bordered bg-white">
                <thead>
                    <tr>
                        <th class="no-sort">Message</th>


                    </tr>
                </thead>




                <tbody>
                    <asp:Repeater ID="rp" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("OperationResult")%></td>


                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>



            </table>
            <!-- END table -->
        </div>
    </div>

</asp:Content>


