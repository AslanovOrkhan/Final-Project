// header section start
let navbar = document.querySelector(".navbar");
document.getElementById("menu-btn").onclick = () => {
  navbar.classList.toggle("active");
  cartItem.classList.remove("active");
  search.classList.remove("active");
};
let search = document.querySelector(".search-form");
document.getElementById("search-btn").onclick = () => {
  search.classList.toggle("active");
  navbar.classList.remove("active");
  cartItem.classList.remove("active");
};
let cartItem = document.querySelector(".cart-items-container");
document.getElementById("cart-btn").onclick = () => {
  cartItem.classList.toggle("active");
  navbar.classList.remove("active");
  search.classList.remove("active");
};
window.onscroll = () => {
  navbar.classList.remove("active");
  cartItem.classList.remove("active");
  search.classList.remove("active");
};
// header section end