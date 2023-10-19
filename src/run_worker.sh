printf "..... Executa Worker ......."

ANGULAR_PATH="tarefas-app/View/worker/"

if [ -d "$ANGULAR_PATH" ]; then
    cd "$ANGULAR_PATH"
    pwd     
    dotnet run
fi
