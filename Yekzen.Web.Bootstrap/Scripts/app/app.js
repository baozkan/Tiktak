$(function () {
    var routing = new Routing('@Url.Content("~/")', '#page', 'welcome');
    routing.init();
});