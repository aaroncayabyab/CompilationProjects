$(function() {
  $("#name").keyup(function() {
    $("#greet").text("Hello " + $(this).val());
  })
})
