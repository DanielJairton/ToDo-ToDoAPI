async function carregarDados() {
    var dados = await fetch(`https://localhost:7057/api/TodoItems`).then(Response => Response.json());
    //console.log(dados);

    //console.log(dados.length);
    if (dados.length < 1) {
        console.log("nenhum item no banco de dados");
        return;
    }
    else{
        for (let index = 0; index < dados.length; index++) {
            //console.log(dados[index]);
            let li = document.createElement('LI');
            let tarefa = dados[index].name;
            let caixaTarefa = document.createTextNode(tarefa);

            li.appendChild(caixaTarefa);//Texto foi criado e entra como lista

            if (dados[index].isComplete == true) {
                li.classList.toggle('checked');
            }

            document.querySelector('ul').appendChild(li); //Essa lista desordenada vai receber o elemento filho
        }
    }
    return dados;
}

carregarDados();

/*function botaoFechar(li){
    
    let span = document.createElement("SPAN");
    // let txt = document.createElement("text");
    // txt.textContent = "\u00D7";
    // let txt = document.createTextNode("\u00D7");

    const btnRemover = document.createElement('button');
    btnRemover.className = "btn-remover btn btn-danger";
    btnRemover.innerHTML = "X";


    span.className = "close";
    span.appendChild(btnRemover)
    // span.appendChild(txt);
    li.appendChild(span);
    span.onclick = () => span.parentElement.style.display = "none";
}*/


//document.querySelectorAll('li').forEach(botaoFechar);

/*document.querySelector('ul').addEventListener('click', (e) => {

    if(e.target.tagName === 'LI'){
        e.target.classList.toggle('checked');
    }
})*/
/*
function addTarefa(){
    let li = document.createElement('LI');
    let tarefa = document.form_main.task.value;
    let caixaTarefa = document.createTextNode(tarefa);

    li.appendChild(caixaTarefa);//Texto foi criado e entra como lista
    document.querySelector('ul').appendChild(li); //Essa lista desordenada vai receber o elemento filho
    document.form_main.task.value = ""; //Após limpa o input

    //botaoFechar(li); //Chama novamente a função
}
*/
