angular.module("services", [])
    .service("navigationService", ["$http", "$location", "$q", NavigationService]);

function NavigationService($http, $location, $q) {
    var self = this;
    self.getTableOfContents = function () {
        return $http.get("/Home/GetTableOfContents", { cache: true });
    };
    self.selectLesson = function (id) {
        var newLesson = $q.defer();
        this.getTableOfContents()
            .success(function (tableOfContents) {
                for (var i = 0; i < tableOfContents.length; i++) {
                    var module = tableOfContents[i];
                    for (var j = 0; j < module.Lessons.length; j++) {
                        var lesson = module.Lessons[j];
                        if (lesson.Id == id) {
                            $location.path("/lessons/" + id);
                            newLesson.resolve(lesson);
                            return;
                        }
                    }
                }
            })
            .error(function () {
                alert("An unexpected error has occurred. Please try again.");
            });

        return newLesson.promise;
    };
}