const card = document.createElement("div");
card.style.backgroundColor = "#f9f9f9ff";
document.body.appendChild(card);

card.style.position = "relative";
card.style.width = "320px";
card.style.border = "1px solid #ccc";
card.style.borderRadius = "10px";
card.style.overflow = "hidden";
card.style.fontFamily = "Arial";
card.style.cursor = "pointer";
card.style.transition = "0.3s";

const heart = document.createElement("i");
heart.className = "fa-regular fa-heart"; 
heart.style.position = "absolute";
heart.style.top = "10px";
heart.style.right = "10px";
heart.style.left = "auto";
heart.style.fontSize = "20px";
heart.style.color = "white";
heart.style.cursor = "pointer";
card.appendChild(heart);

heart.addEventListener("click", (e) => {
  e.stopPropagation(); 
  console.log("Urek kliklendi!");
  heart.style.color = heart.style.color === "red" ? "white" : "red";
});

card.addEventListener("mouseenter", () => {
  card.style.boxShadow = "0 5px 15px rgba(0,0,0,0.3)";
});
card.addEventListener("mouseleave", () => {
  card.style.boxShadow = "none";
});

// IMG
const img = document.createElement("img");
img.src = "https://augueksperts.lv/wp-content/uploads/2013/08/post12-1.jpg";
img.style.width = "100%";
card.appendChild(img);

const content = document.createElement("div");
content.style.padding = "10px";
card.appendChild(content);

const title = document.createElement("p");
title.innerText = "DETACHED HOUSE · 5Y OLD";
title.style.color = "gray";
content.appendChild(title);

const price = document.createElement("h2");
price.innerText = "$750,000";
content.appendChild(price);

const address = document.createElement("p");
address.innerText = "742 Evergreen Terrace";
address.style.color = "gray";
content.appendChild(address);

// INFO
const info = document.createElement("div");
info.style.border = "0.2px solid #dad9d9ff";
info.style.backgroundColor = "#f3f3f3ff";
info.style.padding = "20px";
info.style.display = "flex";
info.style.gap = "15px";
info.style.margin = "20px 0";
content.appendChild(info);

const bedicon= document.createElement("span");
bedicon.innerHTML = '<i class="fa-solid fa-bed"></i> 3 Bedrooms';
info.appendChild(bedicon);

const bathicon = document.createElement("span");
bathicon.innerHTML = '<i class="fa-solid fa-bath"></i> 2 Bathrooms';
info.appendChild(bathicon);

// REALTOR
const realtor = document.createElement("div");
realtor.style.marginTop = "10px";
realtor.style.paddingTop = "10px";
realtor.style.backgroundColor="#f3f3f3ff"
realtor.style.borderTop = "1px solid #eee";
content.appendChild(realtor);

const realtortitle = document.createElement("div");
realtortitle.innerText = "REALTOR";
realtortitle.style.fontSize = "12px";
realtortitle.style.fontWeight = "bold";
realtortitle.style.color = "#56626aff";
realtortitle.style.marginBottom = "10px";
realtortitle.style.paddingLeft = "10px";
realtor.appendChild(realtortitle);

const realtorinfo = document.createElement("div");
realtorinfo.style.display = "flex";
realtorinfo.style.alignItems = "center";
realtorinfo.style.padding = "0 10px";
realtor.appendChild(realtorinfo);

const realtorimg = document.createElement("img");
realtorimg.src = "https://play-lh.googleusercontent.com/w-pTv094bdQGNd4EjW6l6dU07LWKrKFrsBLQJFza9WOqhy1jjzDVgx9PzsFUS9oLaA=w240-h480-rw";
realtorimg.style.width = "40px";
realtorimg.style.height = "40px";
realtorimg.style.borderRadius = "50%";
realtorimg.style.marginRight = "10px";
realtorimg.style.marginBottom = "10px";
realtorinfo.appendChild(realtorimg);

const details = document.createElement("div");
details.style.display = "flex";
details.style.gap = "5px";
details.style.marginBottom = "10px";
details.style.flexDirection = "column";
realtorinfo.appendChild(details);

const realtorname = document.createElement("span");
realtorname.innerText = "Tiffany Heffner";
realtorname.style.fontSize = "14px";
realtorname.style.fontWeight = "bold";
details.appendChild(realtorname);

const realtorphone = document.createElement("span");
realtorphone.innerHTML = '<i class="fa-solid fa-phone"></i> (555) 555-4321';
realtorphone.style.fontSize = "12px";
realtorphone.style.color = "gray";
details.appendChild(realtorphone);


card.addEventListener("click", () => {
  console.log("Card kliklendi!");
});


