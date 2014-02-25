angular.module("angularTutorial", ["ngRoute", "controllers"])
    .config(["$routeProvider", "$locationProvider",
        function ($routeProvider, $locationProvider) {
            $routeProvider.
              when('/lessons/:lessonId', {
                  templateUrl: 'Content/Views/Lesson.html',
                  controller: 'lesson'
              }).
              otherwise({
                  templateUrl: 'Content/Views/Lesson.html',
                  controller: 'lesson'
              });

            $locationProvider.html5Mode(true).hashPrefix('!');
        }
    ]);