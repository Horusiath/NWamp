<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rpc.aspx.cs" Inherits="NWamp.Examples.Rpc" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #calculator {
            padding: 10px;    
        }

        #calc-keyboard {
            margin: 4px;    
        }

        #calc-keyboard .btn {
            width: 35px;
            height: 35px;
        }
    </style>
    <div class="page-header">
        <h1>RPC example - remote calculator</h1>
    </div>

    <div id="calculator" class="well col-md-2" data-bind="with: calculator">
        <p>
            <input type="text" id="calc-display" data-bind="value: display" readonly="readonly"/>
        </p>
        <div id="calc-keyboard">
            <table>
                <tr>
                    <td colspan="3">
                    </td>
                    <td>
                        <button class="btn btn-default" data-bind="click: clear">C</button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button class="btn btn-default" data-bind="click: function () { appendDigit(7); }">7</button>
                    </td>
                    <td>
                        <button class="btn btn-default" data-bind="click: function () { appendDigit(8); }">8</button>
                    </td>
                    <td>
                        <button class="btn btn-default" data-bind="click: function () { appendDigit(9); }">9</button>
                    </td>
                    <td>
                        <button class="btn btn-info" data-bind="click: function () { appendOperator('/'); }">/</button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button class="btn btn-default" data-bind="click: function () { appendDigit(4); }">4</button>
                    </td>
                    <td>
                        <button class="btn btn-default" data-bind="click: function () { appendDigit(5); }">5</button>
                    </td>
                    <td>
                        <button class="btn btn-default" data-bind="click: function () { appendDigit(6); }">6</button>
                    </td>
                    <td>
                        <button class="btn btn-info" data-bind="click: function () { appendOperator('*'); }">*</button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button class="btn btn-default" data-bind="click: function () { appendDigit(1); }">1</button>
                    </td>
                    <td>
                        <button class="btn btn-default" data-bind="click: function () { appendDigit(2); }">2</button>
                    </td>
                    <td>
                        <button class="btn btn-default" data-bind="click: function () { appendDigit(3); }">3</button>
                    </td>
                    <td>
                        <button class="btn btn-info" data-bind="click: function () { appendOperator('-'); }">-</button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button class="btn btn-default" data-bind="click: function () { appendDigit('.'); }">.</button>
                    </td>
                    <td>
                        <button class="btn btn-default" data-bind="click: function () { appendDigit(0); }">0</button>
                    </td>
                    <td>
                        <button class="btn btn-primary" data-bind="click: calculate">=</button>
                    </td>
                    <td>
                        <button class="btn btn-info" data-bind="click: function () { appendOperator('+'); }">+</button>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="scripts" runat="server">
    <script type="text/javascript" src="Scripts/app/rpc.js"></script>
</asp:Content>