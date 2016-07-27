var gulp = require('gulp'), watch = require('gulp-watch');
var sass = require('gulp-sass');
var browserSync = require('browser-sync');
var reload = browserSync.reload;

gulp.task('default', ['sass'], function () {
    return;
});
gulp.task('watch', ['watch'], function () {
    return;
});

gulp.task('sass', function() {
        gulp.src('./Sass/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('./wwwroot/css/'))
        .pipe(reload({stream:true}));
});

gulp.task('watch', function() {
    gulp.watch('./Sass/*.scss', [sass]);
});