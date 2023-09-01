// header section start
let responsivNavbar = document.querySelector(".responsive-header-container");
document.getElementById("menu-btn").onclick = () => {
  responsivNavbar.classList.toggle("active");
  cartItem.classList.remove("active");
  search.classList.remove("active");
};
let search = document.querySelector(".search-form");
document.getElementById("search-btn").onclick = () => {
  search.classList.toggle("active");
  responsivNavbar.classList.remove("active");
  cartItem.classList.remove("active");
};
let cartItem = document.querySelector(".cart-items-container");
document.getElementById("cart-btn").onclick = () => {
  cartItem.classList.toggle("active");
  responsivNavbar.classList.remove("active");
  search.classList.remove("active");
};
window.onscroll = () => {
  responsivNavbar.classList.remove("active");
  cartItem.classList.remove("active");
  search.classList.remove("active");
};
// header section end
// swipper slider start
var swiper = new Swiper(".swiper-container", {
  effect: "flip",
  grabCursor: true,
  loop: true,
  pagination: {
    el: ".swipper-pagination",
  },
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },
});
// swipper slider start
