using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using System;
using System.Threading.Tasks;
using Firebase.Extensions;
using UnityEngine.SceneManagement;
using Proyecto26;

public class FireBaseController : MonoBehaviour
{
    public GameObject loginpanel, signuppanel,ProfilePanel,forgetPasswordpanel,msgerrorpanel,mainpanel, categorypanel,cartpanel,checkoutpanel;
    public InputField loginEmail, loginPassword,SignUpemail,SignUpPass, SignUpCPass,SignUpUser,forgetpassemail;
    public Text notify_title_text, Notify_message,profileUserEmail,profileUserName;
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
    
    public InputField Fullname, address, phone;
    public Text price;
    public GameObject image;
    public string DataBase_Url = "";
    UsersData User = new UsersData();
    bool isSignIn = false;

     void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    public void OpenCHeckoutPanel()
    {

        loginpanel.SetActive(false);
        signuppanel.SetActive(false);
        ProfilePanel.SetActive(false);
        forgetPasswordpanel.SetActive(false);
        mainpanel.SetActive(false);
        categorypanel.SetActive(false);
        cartpanel.SetActive(false);
        checkoutpanel.SetActive(true);

    }
    public void OpenCartPanel()
    {
       
            loginpanel.SetActive(false);
            signuppanel.SetActive(false);
            ProfilePanel.SetActive(false);
            forgetPasswordpanel.SetActive(false);
            mainpanel.SetActive(false);
            categorypanel.SetActive(false);
            cartpanel.SetActive(true);
           checkoutpanel.SetActive(false);

    }
    public void Openloginpanel()
    {
        loginpanel.SetActive(true);
        signuppanel.SetActive(false);
        ProfilePanel.SetActive(false);
        forgetPasswordpanel.SetActive(false);
        mainpanel.SetActive(false);
        categorypanel.SetActive(false);
        cartpanel.SetActive(false);
        checkoutpanel.SetActive(false);
    }
    public void OpenSignuppanel()
    {
        signuppanel.SetActive(true);
        loginpanel.SetActive(false);
        ProfilePanel.SetActive(false);
        forgetPasswordpanel.SetActive(false);
        mainpanel.SetActive(false);
        categorypanel.SetActive(false);
        checkoutpanel.SetActive(false);

        cartpanel.SetActive(false);
    }
    public void Openprofilepanel()
    {
        checkoutpanel.SetActive(false);
        signuppanel.SetActive(false);
        loginpanel.SetActive(false);
        ProfilePanel.SetActive(true);
        forgetPasswordpanel.SetActive(false);
        mainpanel.SetActive(false);
        categorypanel.SetActive(false);
        cartpanel.SetActive(false);
    }
    public void OpenforgetPassanel()
    {
        checkoutpanel.SetActive(false);
        signuppanel.SetActive(false);
        loginpanel.SetActive(false);
        ProfilePanel.SetActive(false);
        forgetPasswordpanel.SetActive(true);
        mainpanel.SetActive(false);
        categorypanel.SetActive(false);
        cartpanel.SetActive(false);
    }
    public void OpenmainuPanel()
    {
        checkoutpanel.SetActive(false);
        signuppanel.SetActive(false);
        loginpanel.SetActive(false);
        ProfilePanel.SetActive(false);
        forgetPasswordpanel.SetActive(false);
        mainpanel.SetActive(true);
        categorypanel.SetActive(false);
        cartpanel.SetActive(false);
    }
    public void OpenCategoriesPanel()
    {
        cartpanel.SetActive(false);
        signuppanel.SetActive(false);
            loginpanel.SetActive(false);
            ProfilePanel.SetActive(false);
            forgetPasswordpanel.SetActive(false);
            mainpanel.SetActive(false);
            categorypanel.SetActive(true);
        checkoutpanel.SetActive(false);
    }
    
    public void LoginUser()
    {
        if(string.IsNullOrEmpty(loginEmail.text)&& string.IsNullOrEmpty(loginPassword.text))
        {
            ShowNotify("error", "forget email empty");
            return;
        }
        //DO login
        SignInUser(loginEmail.text, loginPassword.text);
     
        OpenCartPanel();
    }
    public void SignUp()
    {
        if (string.IsNullOrEmpty(SignUpemail.text) && string.IsNullOrEmpty(SignUpPass.text) && string.IsNullOrEmpty(SignUpCPass.text) && string.IsNullOrEmpty(SignUpUser.text))
        {
            ShowNotify("error", "forget cell empty");
            return;
        }
        CreateUser(SignUpemail.text, SignUpPass.text,SignUpUser.text);
    }
    public void Forgetpass()
    {
        if (string.IsNullOrEmpty(forgetpassemail.text))
        {
            ShowNotify("error", "forget email empty");
            return;
        }
        forgetPasswordsubmit(forgetpassemail.text);


    }
    private void ShowNotify(string title,string message)
    {
        notify_title_text.text = "" + title;
        Notify_message.text = "" + message;
        msgerrorpanel.SetActive(true);
    }
    public void CloseNotify_panel()
    {
        notify_title_text.text = "" ;
        Notify_message.text = "" ;
        msgerrorpanel.SetActive(false);
    }
    public void LogOut()
    {
        auth.SignOut();
        profileUserEmail.text = "";
        profileUserName.text = "";
        Openloginpanel();
    }
    void CreateUser(string email,string password,string username)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        ShowNotify("error", GetErrorMessage(errorCode));
                    }
                }
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            UpdateProfile(username);
        });
       
    }
    public void SignInUser(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        ShowNotify("error", GetErrorMessage(errorCode));
                    }
                }
                    return;
                }
            

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            profileUserName.text = "" + newUser.DisplayName;
            profileUserEmail.text = "" + newUser.Email;
           // Openprofilepanel();


        });
 
    }
    public void showprofile()
    {
        profileUserName.text = "" + user.DisplayName;
        profileUserEmail.text = "" + user.Email;
        Openprofilepanel();
    }
    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                isSigned = true;
            }
        }
    }
     void OnDestroy()
    {
        Debug.Log(auth);
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }
     void UpdateProfile(string username)
    {
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
            {
                DisplayName = username,
                PhotoUrl = new System.Uri("https://via.placeholder.com/150%20C/O%20https://placeholder.com/"),
            };
            user.UpdateUserProfileAsync(profile).ContinueWithOnMainThread(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("User profile updated successfully.");
                ShowNotify("Alert", "Account Sucssfully Created");
            });
        }
    }
    bool isSigned = false;
     void Update()
    {
        if (isSignIn)
        {
            if(!isSigned)
            {
                isSigned = true;
                profileUserName.text = "" + user.DisplayName;
                profileUserEmail.text = "" + user.Email;
                //Openprofilepanel();
            }

        }
    }
    private static string GetErrorMessage(AuthError errorCode)
    {
        var message = "";
        switch (errorCode)
        {
            case AuthError.AccountExistsWithDifferentCredentials:
                message = "Account does not exist";
                break;
            case AuthError.MissingPassword:
                message = "Missing Password";
                break;
            case AuthError.WeakPassword:
                message = "password So Weak";
                break;
            case AuthError.WrongPassword:
                message = "Password Not Correct";
                break;
            case AuthError.EmailAlreadyInUse:
                message = "Your Email Already Use";
                break;
            case AuthError.InvalidEmail:
                message = "Your Email Invalid";
                break;
            case AuthError.MissingEmail:
                message = "Missing Email";
                break;
            default:
                message = "Invalid error";
                break;
        }
        return message;
    }
   
    void forgetPasswordsubmit(string forgetPassword)
    {
        auth.SendPasswordResetEmailAsync(forgetPassword).ContinueWithOnMainThread(task =>
        {
            if(task.IsCanceled)
            {
                Debug.LogError("SendPasswordResetEmailAsync was cancled");
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        ShowNotify("Error", GetErrorMessage(errorCode));
                    }
                }
            }
            ShowNotify("Alert!", "Successfully Send Email for Reset Password ");
        });
    }
    public void SaveData(int ItemIndex)
    {
       
        User.username = Fullname.text;
        User.Address = address.text;
        User.price = price.text;
        User.phone = phone.text;
        User.img = Profile.Instance.ProductsList[ItemIndex].Image;
        if (string.IsNullOrEmpty(Fullname.text) && string.IsNullOrEmpty(address.text) && string.IsNullOrEmpty(phone.text) && string.IsNullOrEmpty(price.text))
        {
            ShowNotify("Error!", "Missin Field empty");
            return;
        }
       else
        {
            RestClient.Post(DataBase_Url + "/" + User.username + ".json", User);
            ShowNotify("Perfect!", "Odered sent successfully");
        }
    }

}
