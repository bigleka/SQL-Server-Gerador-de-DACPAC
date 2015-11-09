# SQL-Server-Gerador-de-DACPAC
#Este app ainda está em desenvolvimento.
# Versão 1.0 Beta
#Ele é uma versão em Visual Studio 2013 c# para um outra outra versão que fiz em powershell http://leka.com.br/2015/04/03/gerar-dacpac-usando-powershell-v2/
#Ele deve gerar um arquivo com o "nome da base selecionada".dacpac para que possa ser comparado com uma base no SQL, projeto no VS ou no TFS.
#
# Bugs conhecidos nesta versão:
# 1. No diretório de destino, caso seja selecionado um diretório que contenha espaço no nome, ele não executa nada e sai com exceção.
#
# O que ainda falta:
# 1. Adicionar ao final do nome do arquivo um _YYYYMMDD.dacpac para ter o controle da data de geração.
