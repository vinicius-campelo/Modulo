//CRUD VINICIUS CAMPELO
var myApp = angular.module('myApp', ['angularUtils.directives.dirPagination']);

function MyController($scope, $http) {
	$scope.data = new Array;
	$scope.currentPage = 1;
	$scope.pageSize = 5;
	$scope.meals = [];


	$scope.getPeople = function () {
		$http({
			method: 'GET',
			url: '../Home/RetornoJson',
			contentType: "application/json; charset=utf-8",
			dataType: 'JSON',
			async: true,
		}).then(function (response) {
			if (response.data.length > 0) {
				$scope.meals = response.data;
				for (var i = 0; i < response.data.length; i++) {
					var value = new Date(
							parseInt(response.data[i].Data.replace(/(^.*\()|([+-].*$)/g, ''))
					);
					$scope.meals[i].Data = value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear();

					if (response.data[i].Prioridade === "1") {
						$scope.meals[i].Prioridade = "ALTA";
					} else if (response.data[i].Prioridade === "2") {
						$scope.meals[i].Prioridade = "MEDIA";
					} else if (response.data[i].Prioridade === "3") {
						$scope.meals[i].Prioridade = "BAIXA";
					}
					if (response.data[i].Status === true) {
						$scope.meals[i].Status = "fas fa-lock-open";
						
					} else {
						$scope.meals[i].Status = "fas fa-lock";
						
					}
				}
			}
		}, function (response) { });
	};


	$scope.pageChangeHandler = function (num) {
		console.log('meals page changed to ' + num);
	};


	$scope.getDelet = function (id) {

		$http({
			method: 'GET',
			url: '/Home/Remove/' + id,
			data: { id: id },
			headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
		}).then(function (response) {

			document.querySelector('#ativ-' + id).remove();

		}, function (response) {

			console.log(response.data, response.status);

		});
	};

	$scope.getPeople();

	
	$scope.deletEvent = function () {

		var el = document.getElementsByTagName("input");

		for (var i = 0; i < el.length; i++) {
			if (el[i].checked === true) {

				$scope.getDelet(el[i].value);
				if (i < el.length) {
					$scope.getPeople();
					$("#mdelet").modal('hide');
				}
			}
		}
		
	}
	

	$("#deletaLinha").click(function () {

		var el = document.getElementsByTagName("input");

		for (var i = 0; i < el.length; i++) {
			if (el[i].checked === true) {
				$('#btnComfirmaModal').show()
				$('#excluiArquivo').html("<span>Deseja realmente excluir!</span>");
				$("#mdelet").modal('show');
				break;
			}


			if (el[i].checked === false) {
				$('#btnComfirmaModal').hide();
				$('#excluiArquivo').html("<span>Nemhum item foi selecionado!</span>");
				$("#mdelet").modal('show');
			}
		}
    });

}

function OtherController($scope) {
	$scope.pageChangeHandler = function (num) {
		console.log('ir para a pagina ' + num);
	};
}


myApp.controller('MyController', MyController);
myApp.controller('OtherController', OtherController);