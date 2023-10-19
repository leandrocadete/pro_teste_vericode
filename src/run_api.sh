printf "..... Executa Angular ......."

ANGULAR_PATH="tarefas-app/View/web-api/"

if [ -d "$ANGULAR_PATH" ]; then
    cd "$ANGULAR_PATH"
    pwd 
    dotnet run
fi
