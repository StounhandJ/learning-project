package mpt.ru.mar.news;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.text.method.HideReturnsTransformationMethod;
import android.text.method.PasswordTransformationMethod;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    EditText txtLogin, txtPassword;
    DatabaseHelper databaseHelper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initialize();
    }

    private void initialize() {
        txtLogin = findViewById(R.id.txtLogin);
        txtPassword = findViewById(R.id.txtPassword);
        databaseHelper = new DatabaseHelper(this);
    }

    public void enterClick(View view) {
        Intent intent = new Intent(this, AllNewsActivityAdministrator.class);
        Cursor res = databaseHelper.getData(txtLogin.getText().toString().trim(), txtPassword.getText().toString().trim());
        if (res.getCount() == 0) {
            Toast.makeText(this, "Неверный логин или пароль", Toast.LENGTH_SHORT).show();
            return;
        }
        while (res.moveToNext()) {
            if (res.getString(3).equals("Администратор")) {
                intent.putExtra("Id", res.getInt(0));
                startActivity(intent);
            } else {
                startActivity(new Intent(this, AllNewsActivity.class));
            }
        }
    }

    public void registrationClick(View view) {
        startActivity(new Intent(this, RegistrationActivity.class));
    }
}