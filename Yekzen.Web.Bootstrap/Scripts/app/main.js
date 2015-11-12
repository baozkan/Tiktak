﻿// initialize the application
require.config({
    //urlArgs: "bust=" + (new Date()).getTime(),
    paths: {
        jquery: '../jquery-2.1.4',
        bootstrap: '../bootstrap',
        underscore: '../underscore',
        backbone: '../backbone',
        templates: '../../templates'
    }
});

// Load our app module and pass it to our definition function
require(['app',], function (main) {
    // The "app" dependency is passed in as "main"
    // Again, the other dependencies passed in are not "AMD" therefore don't pass a parameter to this function
    main.initialize();
});