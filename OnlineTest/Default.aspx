<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineTest._Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script>
		$(function () {

			function start() {
				$.ajax({
					url: 'api/combat/start',
					type: 'POST',
					contentType: "application/json;charset=utf-8",
					success: function (data) {
						vm.combat(data);
					},
					error: function (data) {
					}
				});
			}
			function attack(npc) {
				$.ajax({
					url: 'api/combat/attack/'+npc.Id,
					type: 'POST',
					contentType: "application/json;charset=utf-8",
					success: function (data) {
						vm.combat(data);
					},
					error: function (data) {
					}
				});
			}

			var vm = {
				combat: ko.observable(),
				start: start,
				attack: attack
			}

			ko.applyBindings(vm);
		});
	</script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


	<div class="row">
		<button data-bind="click: start">Start</button>
		<div data-bind="if: combat()">
			<label data-bind="text: combat().Player.Hp"></label>
			<ul data-bind="foreach: combat().NPCs">
				<li>
					<label data-bind="text: Hp"></label>
					<button data-bind="click: $root.attack">Go</button>
				</li>
			</ul>
		</div>
	</div>

</asp:Content>
