angular.module("services", [])
    .service("navigationService", ["$http", "$location", "$q", NavigationService]);

function NavigationService($http, $location) {
    var self = this;
    self.selectedLesson = null;
    self.getTableOfContents = function () {
        return $http.get("/Home/GetTableOfContents", { cache: true });
    };
    self.selectLesson = function (id) {
        this.getTableOfContents()
            .success(function (tableOfContents) {
                for (var i = 0; i < tableOfContents.length; i++) {
                    var module = tableOfContents[i];
                    for (var j = 0; j < module.Lessons.length; j++) {
                        var lesson = module.Lessons[j];
                        if (lesson.Id == id) {
                            $location.path("/lessons/" + id);
                            self.selectedLesson = lesson;
                            return;
                        }
                    }
                }
            })
            .error(function () {
                alert("An unexpected error has occurred. Please try again.");
            });
    };

    self.selectedLesson = self.getTableOfContents()
        .success(function (tableOfContents) {
            self.selectLesson(tableOfContents[0].Lessons[0]);
        });
}