namespace RelationshipManyToMany {

    angular.module('RelationshipManyToMany', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: RelationshipManyToMany.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: RelationshipManyToMany.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('addActorToMovie', {
                url: '/addActorToMovie/:id',
                templateUrl: '/ngApp/views/addActorToMovie.html',
                controller: RelationshipManyToMany.Controllers.AddActorToMovieController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    

}
