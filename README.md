**How to Run the application (frontend and backend)**

_Backend (.NET Web API)_ :

                          Navigate to backend directory:
                            Open the terminal (cmd.exe) and give a command -    cd Prescription_Management_API
                                                                                dotnet build
                                                                                dotnet run
                                                  
                              API will run at : https://localhost:7046
                              Swagger :         https://localhost:7046/swagger/index.html


_Frontend (React)_ :

                          Navigate to frontend directory:
                             give a command - cd PRESCRIPTION_MANAGEMENT_APP**
                                            Install dependencies and start:

                                              npm install
                                              npm run dev
                              App will open at http://localhost:5173

_Assumptions/Shortcuts_ :

                          No authentication implemented (all routes are open)
                          In-memory storage used instead of real database
                          Basic error handling without detailed user feedback
                          Development CORS policy (allow-all origins)

_Known Limitations_    :

                          Data Persistence:
                                Data only persists while server is running
                                Resets when server restarts (unless using JSON file option)

_Scalability_          :

                          Not suitable for large number of records
                          No pagination implemented

_Validation_           :
                          
                          Basic validation only
                          No duplicate prescription checks

_UI_                  :

                          No loading states during API calls
                          Basic form validation only

_Development Details_ :

                          Time Taken: 5 hours total development

_Incomplete Parts_       :

                          Advanced search/filter functionality
                          Prescription edit/delete operations
                          Patient management interface
                          Proper error handling UI
                          Unit/Integration tests
