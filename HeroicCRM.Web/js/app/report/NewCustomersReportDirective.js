(function() {
	'use strict';

	window.app.directive('newCustomersReport', newCustomersReport);

	function newCustomersReport() {
		return {
			scope: true,
			templateUrl: '/js/app/report/templates/newCustomersReport.tmpl.html',
			controller: controller,
			controllerAs: 'vm'
		}
	}

	controller.$inject = ['$http'];
	function controller($http) {
		var vm = this;

		vm.isLoading = true;

		$http.post('/Report/NewCustomers')
			.success(function (customers) {
				vm.customers = customers;
				vm.isLoading = false;
			});
	}
})();