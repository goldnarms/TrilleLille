var gulp = require('gulp'), watch = require('gulp-watch');
var sass = require('gulp-sass');
var browserSync = require('browser-sync');
var reload = browserSync.reload;
var shell = require('gulp-shell');
var ts = require('gulp-typescript');
var rename = require('gulp-rename');
var uglify = require('gulp-uglify');
var print = require('gulp-print');  

gulp.task('default', ['sass', 'typescript'], function () {
    return;
});
gulp.task('watch', ['watch'], function () {
    return;
});

gulp.task('sass', function() {
        gulp.src('./Sass/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('./wwwroot/css/'))
        .pipe(reload({stream:true}));
});

gulp.task('watch', function() {
    gulp.watch('./Sass/**/*.scss', [sass]);
});

gulp.task('installTypings',
    shell.task([
        'typings install'
    ]));

gulp.task('typescript', ['installTypings'], function () {
    return gulp.src('Ts/**/*.ts')
		.pipe(ts({
		    target: 'ES5'
		}))
        .pipe(uglify())
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(print(function (filepath) {
            return "transpiled from ts: " + filepath;
        }))
        .pipe(gulp.dest('./wwwroot/js/'));
});