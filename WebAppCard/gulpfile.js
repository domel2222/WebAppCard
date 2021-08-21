/// <binding AfterBuild='default' />
var gulp = require("gulp");
var uglify = require("gulp-uglify")
var concat = require("gulp-concat")

// minify Java Script

function minify() {
    return gulp.src(["wwwroot/js/**/*.js"])
        .pipe(uglify())
        .pipe(concat("webcard.min.js"))
        .pipe(gulp.dest("wwwroot/dist/"))
}


//minify Css

function styles() {
    return gulp.src(["wwwroot/js/**/*.js"])
        .pipe(uglify())
        .pipe(concat("webcard.min.css"))
            .pipe(gulp.dest("wwwroot/dist/"))
}

//exports.minify = minify;
//exports.styles = styles;

exports.default = gulp.parallel(minify, styles);
