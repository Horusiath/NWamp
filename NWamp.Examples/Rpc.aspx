<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rpc.aspx.cs" Inherits="NWamp.Examples.Rpc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var session, fst, sec, result, add, sub, mul, div;
        var wsuri = "ws://localhost:3333";
        
        function calculateHandler(uri) {
            var x = +(fst.val()),
                y = +(sec.val());
            
            session.call("http://localhost:3333" + uri, x, y).then(
                function (res) { console.log(res); result.val(res); },
                function (error, desc) { console.log("error: " + desc); }
            );
        }

        $(function () {
            fst = $('#first-no');
            sec = $('#second-no');
            result = $('#result');
            add = $('#btn-add');
            sub = $('#btn-sub');
            mul = $('#btn-mul');
            div = $('#btn-div');
            
            ab.connect(wsuri,
              function (sess) {
                  session = sess;
              },
              function (code, reason) {
                  console.log(reason);
              }
            );

            add.click(function () {
                calculateHandler("/Calculator#Add");
            });
            
            sub.click(function () {
                calculateHandler("/Calculator#Sub");
            });
            
            mul.click(function () {
                calculateHandler("/Calculator#Mul");
            });
            
            div.click(function () {
                calculateHandler("/Calculator#Div");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-inline" role="form">
        <div class="form-group">
            <label class="sr-only" for="first-no">First number</label>
            <input type="number" class="form-control" id="first-no" placeholder="First number">
        </div>
        <div class="form-group">
            <label class="sr-only" for="second-no">Password</label>
            <input type="number" class="form-control" id="second-no" placeholder="Second number">
        </div>
        <button id="btn-add" class="btn btn-default">+</button>
        <button id="btn-sub" class="btn btn-default">-</button>
        <button id="btn-mul" class="btn btn-default">*</button>
        <button id="btn-div" class="btn btn-default">/</button>
        <div class="form-group">
            <label class="sr-only" for="result">Password</label>
            <input type="number" class="form-control" id="result" placeholder="Result" readonly="readonly">
        </div>
    </div>
</asp:Content>
