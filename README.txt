Esse projeto visa desenvolver o desafio do APP "Pesquisa Cep" em Xamarin.


Aba 1 - Consulta e gravação de CEP - Modo Online
------------------------------------------------
A busca é realizado por meio um request HTTP utilizando o Webservice indicado: https://viacep.com.br/.
O Webservice retorna um arquivo JSON que é desserializado para ser formatado para exibição e salvo.
O armazenamento do histórico da busca é feito em um arquivo "ceps.txt".

Aba 2 - Consulta de CEP - Modo Offline
--------------------------------------
A aba faz a leitura do arquivo "ceps.txt" com o método "onAppearing" e o exibe na página, para que ela
seja atualizada toda vez que ficar visível.

Aba 3 - Mapa com as localidades salvas
--------------------------------------
A ser implementado.