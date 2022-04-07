package mpt.ru.mar.news;

import androidx.appcompat.app.AppCompatActivity;

import android.database.Cursor;
import android.os.Bundle;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    CheckBox is_admin;
    EditText name, password;
    Button reg, log;
    DatabaseHelper dataBaseHelper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        reg = findViewById(R.id.btnReg);
        log = findViewById(R.id.btnLog);
        name = findViewById(R.id.txtName);
        password = findViewById(R.id.txtPassword);
        is_admin = findViewById(R.id.isAdmin);
        dataBaseHelper = new DatabaseHelper(this);


        reg.setOnClickListener(view -> {
            Boolean checkInsertData = dataBaseHelper.insertUser(name.getText().toString(), password.getText().toString(), is_admin.isChecked()?1:0);
        });

        log.setOnClickListener(view -> {
            Cursor res = dataBaseHelper.getUserByLoginPassword(name.getText().toString(), password.getText().toString());
            if (res.getCount() != 1) {
                Toast.makeText(getApplicationContext(), "Нет данных", Toast.LENGTH_LONG).show();
                return;
            }
            res.moveToNext();
            int is_admin = res.getInt(2);
            Toast.makeText(getApplicationContext(), "Логин "+res.getString(0), Toast.LENGTH_LONG).show();
        });
    }
}