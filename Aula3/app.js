const links = document.querySelectorAll(".navbar li a");

links.forEach( link => {
    link.addEventListener("click", () => {
        
        // Removendo o Active de todos os link
        links.forEach( l => l.classList.remove("active"));

        // Adicionando o Active para o item selecionado
        link.classList.add("active");
    });
});