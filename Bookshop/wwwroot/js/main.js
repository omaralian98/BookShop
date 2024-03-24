// show and hide password
$(".pass-feild i").click(() => {
    $(".pass-feild i").toggleClass("fa-eye-slash");
    $(".pass-feild i").toggleClass("fa-eye");
    if ($(".pass-feild i").hasClass("fa-eye")) {  
        $('#pass').attr('type', 'text');
    }
    else {
        $('#pass').attr('type', 'password');
    }
});


// get login data and login
let loginUserName = $('.form.login #username');
let loginPassword = $('.form.login #pass');

$('.form.login button').click((e) => {
    if (loginUserName.val() ==='') {
        $('.form.login .error-pass').css("display", "none")
        $('.form.login .error-user').css("display", "block")
        e.preventDefault();
    }
    else if (loginPassword.val() ==='') {
        $('.form.login .error-user').css("display", "none")
        $('.form.login .error-pass').css("display", "block")
        e.preventDefault();
    }
    else {
        $('.form.login .error-user').css("display", "none")
        $('.form.login .error-pass').css("display", "none")
    }
})


// get signup data and signup
let signupUserName = $('.form.signup #username');
let signupPassword = $('.form.signup #pass');
let signupEmail = $('.form.signup #email');
let signupPhone = $('.form.signup #phone');
let signupBirth = $('.form.signup #birth');


$('.form.signup button').click((e) => {
    var mailFormat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var birthDate = new Date(signupBirth.val());
    var age = (new Date()).getFullYear() - birthDate.getFullYear();

    if (signupUserName.val() === '') {
        $('.form.signup .error-pass').css("display", "none")
        $('.form.signup .error-email').css("display", "none")
        $('.form.signup .error-phone').css("display", "none")
        $('.form.signup .error-birth').css("display", "none")
        $('.form.signup .error-user').css("display", "block")
        e.preventDefault();
    }
    else if (signupPassword.val() === '') {
        $('.form.signup .error-user').css("display", "none")
        $('.form.signup .error-email').css("display", "none")
        $('.form.signup .error-phone').css("display", "none")
        $('.form.signup .error-birth').css("display", "none")
        $('.form.signup .error-pass').css("display", "block")
        e.preventDefault();
    }
    else if(!signupEmail.val().match(mailFormat)) {
        $('.form.signup .error-user').css("display", "none")
        $('.form.signup .error-pass').css("display", "none")
        $('.form.signup .error-phone').css("display", "none")
        $('.form.signup .error-birth').css("display", "none")
        $('.form.signup .error-email').css("display", "block")
        e.preventDefault();
    }
    else if ((signupPhone.val() != '') && (signupPhone.val().length != 13) ||
        (signupPhone.val() != '') && (!$.isNumeric(signupPhone.val()))) {
            $('.form.signup .error-user').css("display", "none")
            $('.form.signup .error-pass').css("display", "none")
            $('.form.signup .error-email').css("display", "none")
            $('.form.signup .error-birth').css("display", "none")
            $('.form.signup .error-phone').css("display", "block")
            e.preventDefault();
    }
    else if (age < 8 || age > 90 || signupBirth.val() === "" ) {
        $('.form.signup .error-user').css("display", "none")
        $('.form.signup .error-pass').css("display", "none")
        $('.form.signup .error-email').css("display", "none")
        $('.form.signup .error-phone').css("display", "none")
        $('.form.signup .error-birth').css("display", "block")
        e.preventDefault();
    }
    else {
        $('.form.signup .error-user').css("display", "none")
        $('.form.signup .error-pass').css("display", "none")
        $('.form.signup .error-email').css("display", "none")
        $('.form.signup .error-phone').css("display", "none")
        $('.form.signup .error-birth').css("display", "none")
    }
})


// get recover data and recover
let recoverEmail1 = $('.form.recover #email');
let recoverEmail2 = $('.form.recover #r_email');


$('.form.recover button').click((e) => {
    var mailFormat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if(!recoverEmail1.val().match(mailFormat) ||
        !recoverEmail2.val().match(mailFormat)){
        $('.form.recover .error-email').css("display", "block")
        e.preventDefault();
    }
    else if (recoverEmail1.val() !== recoverEmail2.val()) {
        $('.form.recover .error-email').css("display", "none")
        $('.form.recover .error-validation').css("display", "block")
        e.preventDefault();
    }
    else {
        $('.form.recover .error-email').css("display", "none")
        $('.form.recover .error-validation').css("display", "none")
        e.preventDefault();
    }
})