angular.module("angularTutorial", ["ngRoute", "controllers"])
    .config(["$routeProvider",
        function ($routeProvider) {
            $routeProvider.
              when('/Lessons/:lessonId', {
                  templateUrl: 'Content/Views/Lesson.html',
                  controller: 'lesson'
              }).
              when('/About', {
                  templateUrl: 'Content/Views/About.html',
              }).
              otherwise({
                  templateUrl: 'Content/Views/Lesson.html',
                  controller: 'lesson'
              });
        }
    ]);